using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TestClient
{
    public partial class Form1 : Form
    {
        private string username;
        private int selectedTestId;
        private int currentQuestionIndex;
        private int correctAnswerCount;
        private Test[] availableTests;
        private Question[] currentTestQuestions;
        private Test selectedTest;
        private int currentQuestion = 0;
        private const string BaseUrl = "http://localhost:5000/api/";
        private readonly HttpClient _httpClient = new HttpClient();
       

        


        public Form1()
        {
            InitializeComponent();
            fillContents();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

       


        private void fillContents()
        {
            label1.Text = "Welcome!";
            testsListBox.Items.Add("Test 1");
            testsListBox.Items.Add("Test 2");
            testsListBox.Items.Add("Test 3");
            questionLabel.Text = "What is your name?";
            answerARadioButton.Text = "John";
            answerBRadioButton.Text = "Mary";
            answerCRadioButton.Text = "Jane";
            answerDRadioButton.Text = "Bob";
            feedbackLabel.Text = "";

            // Populate dgvGroupTests with default data
            DataTable dtGroupTests = new DataTable();
            dtGroupTests.Columns.Add("TestName", typeof(string));
            dtGroupTests.Columns.Add("GroupName", typeof(string));
            dtGroupTests.Rows.Add("Test 1", "Group A");
            dtGroupTests.Rows.Add("Test 2", "Group B");
            dtGroupTests.Rows.Add("Test 3", "Group C");

            // Populate dgvUsers with default data
            DataTable dtUsers = new DataTable();
            dtUsers.Columns.Add("Name", typeof(string));
            dtUsers.Columns.Add("Email", typeof(string));
            dtUsers.Rows.Add("John Smith", "john.smith@example.com");
            dtUsers.Rows.Add("Jane Doe", "jane.doe@example.com");
            dtUsers.Rows.Add("Bob Johnson", "bob.johnson@example.com");

        }



        private bool Authenticate(string username, string password)
        {
            // Підключення до бази даних
            string connectionString = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Формуємо SQL-запит для вибірки користувача з бази даних за логіном та паролем
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password";

                // Створюємо об'єкт команди для виконання SQL-запиту
                SqlCommand command = new SqlCommand(query, connection);

                // Додаємо параметри до команди
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                // Виконуємо SQL-запит та отримуємо кількість записів, що задовольняють умову
                int count = (int)command.ExecuteScalar();

                // Якщо знайдено користувача з відповідним логіном та паролем, повертаємо true, інакше - false
                return count > 0;
            }
        }



        // Метод для завантаження доступних тестів з сервера
        private Test[] LoadTests()
        {
            // Встановити рядок підключення до бази даних
            string connectionString = "your_connection_string_here";

            // Створити з'єднання з базою даних
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Відкрити з'єднання
                connection.Open();

                // Створити запит для отримання тестів
                string query = "SELECT TestId, TestName, Description FROM Tests";

                SqlCommand command = new SqlCommand(query, connection);

                // Виконати запит та отримати результати
                SqlDataReader reader = command.ExecuteReader();

                // Створити список для зберігання тестів
                List<Test> tests = new List<Test>();

                // Читати результати та додавати тест до списку
                while (reader.Read())
                {
                    int testId = reader.GetInt32(0);
                    string testName = reader.GetString(1);
                    string description = reader.GetString(2);

                    tests.Add(new Test
                    {
                        Id = testId,
                        Name = testName,
                        Description = description
                    });
                }

                // Повернути масив тестів
                return tests.ToArray();
            }
        }



        // Метод для відображення доступних тестів в ListBox
        private void PopulateTestsListBox()
        {
            // очистити ListBox
            testsListBox.Items.Clear();

            // завантажити доступні тести з сервера
            availableTests = LoadTests();

            // додати назви тестів до ListBox
            foreach (Test test in availableTests)
            {
                testsListBox.Items.Add(test.Name);
            }
        }


        // Метод для початку тестування
        private void StartTest()
        {
            // завантажити запитання для вибраного тесту
            currentTestQuestions = LoadQuestions(selectedTestId);

            // встановити поточний індекс запитання
            currentQuestionIndex = 0;

            // встановити кількість правильних відповідей
            correctAnswerCount = 0;

            // відображення першого запитання
            DisplayQuestion(currentTestQuestions[currentQuestionIndex]);
        }


        private Question[] LoadQuestions(int testId)
        {
            // Встановити рядок підключення до бази даних
            string connectionString = "your_connection_string_here";

            // Створити з'єднання з базою даних
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Відкрити з'єднання
                connection.Open();

                // Створити запит для отримання запитань для тесту з заданим ідентифікатором
                string query = "SELECT q.QuestionId, q.QuestionText, a.AnswerId, a.AnswerText, a.IsCorrect " +
                               "FROM Questions q " +
                               "INNER JOIN Answers a ON q.QuestionId = a.QuestionId " +
                               "WHERE q.TestId = @TestId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestId", testId);

                // Виконати запит та отримати результати
                SqlDataReader reader = command.ExecuteReader();

                // Створити словник для зберігання запитань та відповідей
                Dictionary<int, Question> questions = new Dictionary<int, Question>();

                // Читати результати та додавати запитання та відповіді до словника
                while (reader.Read())
                {
                    int questionId = reader.GetInt32(0);
                    string questionText = reader.GetString(1);
                    int answerId = reader.GetInt32(2);
                    string answerText = reader.GetString(3);
                    bool isCorrect = reader.GetBoolean(4);

                    // Перевірити, чи запитання вже є в словнику, якщо ні - додати
                    if (!questions.ContainsKey(questionId))
                    {
                        questions[questionId] = new Question
                        {
                            QuestionId = questionId,
                            Text = questionText,
                            Answers = new List<Answer>()
                        };
                    }

                    // Додати відповідь до запитання
                    questions[questionId].Answers.Add(new Answer
                    {
                        AnswerId = answerId,
                        AnswerText = answerText,
                        IsCorrect = isCorrect
                    });
                }

                // Повернути список запитань зі словника

                List<Question> questionsList = new List<Question>(questions.Values);
                Question[] questionsArray = questionsList.ToArray();


                return questionsArray;
            }
        }

        private void clearForm()
        {
            
        }

        // Метод для відображення запитання на формі
        // Метод для відображення запитання на формі
        private void DisplayQuestion(Question question)
        {
            // очистити контроли форми для відображення запитання
            ClearQuestionControls();

            // відображення тексту запитання
            questionLabel.Text = question.Text;

            // відображення варіантів відповідей
            answerARadioButton.Text = question.AnswerA.AnswerText;
            answerBRadioButton.Text = question.AnswerB.AnswerText;
            answerCRadioButton.Text = question.AnswerC.AnswerText;
            answerDRadioButton.Text = question.AnswerD.AnswerText;



            // змінити назву кнопки "Наступне запитання" на "Завершити тест", якщо це останнє запитання
            if (currentQuestionIndex == currentTestQuestions.Length - 1)
            {
                nextQuestionButton.Text = "Завершити тест";
            }
        }



        // Метод для очищення контролів для відображення запитання
        private void ClearQuestionControls()
        {
            questionLabel.Text = "";
            answerARadioButton.Text = "";
            answerBRadioButton.Text = "";
            answerCRadioButton.Text = "";
            answerDRadioButton.Text = "";
            answerARadioButton.Checked = false;
            answerBRadioButton.Checked = false;
            answerCRadioButton.Checked = false;
            answerDRadioButton.Checked = false;
            feedbackLabel.Text = "";
        }


        // Метод для перевірки відповіді на запитання та відображення результату
        private void CheckAnswer(Question question, Answer selectedAnswer)
        {
            // якщо відповідь правильна
            if (selectedAnswer == question.CorrectAnswer)
            {
                feedbackLabel.Text = "Правильно!";
                correctAnswerCount++;
            }
            // якщо відповідь неправильна
            else
            {
                feedbackLabel.Text = $"Неправильно. Правильна відповідь: {question.CorrectAnswer}";
            }
        }


        // Обробник події для натискання кнопки "Увійти"
        private void loginButton_Click(object sender, EventArgs e)
        {
            // перевірити логін та пароль на сервері
            if (Authenticate(usernameTextBox.Text, passwordTextBox.Text))
            {
                // очистити тексти логіну та пароля
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";

                // відобразити доступні тести в ListBox
                PopulateTestsListBox();

                // показати ListBox для вибору тесту
                testsGroupBox.Visible = true;

                // приховати панель для вводу логіну та пароля
                loginGroupBox.Visible = false;
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль. Спробуйте ще раз.");
            }
        }


        // Обробник події для вибору тесту в ListBox
        private void testsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // зберегти обраний тест
            selectedTestId = availableTests[testsListBox.SelectedIndex].Id;

            // приховати ListBox для вибору тесту
            testsGroupBox.Visible = false;

            // почати тестування
            StartTest();

            // показати контроли для відображення запитань
            questionGroupBox.Visible = true;
            answerGroupBox.Visible = true;
            feedbackLabel.Visible = true;
        }


        // Обробник події для натискання кнопки "Наступне запитання"
        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            // Перевірити, чи вибрана відповідь на поточне запитання
            if (!checkAnswer())
            {
                // Якщо відповідь не вибрана, показати повідомлення про помилку
                MessageBox.Show("Виберіть відповідь на поточне запитання!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Записати відповідь на поточне запитання
            saveAnswer();

            // Якщо це останнє запитання, закінчити тестування
            if (currentQuestion == selectedTest.questions.Count - 1)
            {
                finishTest();
                return;
            }

            // Інакше, показати наступне запитання
            currentQuestion++;
            
        }


        


        private bool checkAnswer()
        {
            foreach (Control control in answerGroupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Збереження відповіді на поточне запитання
        private void saveAnswer()
        {
            string selectedAnswer = "";
            foreach (Control control in answerGroupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        selectedAnswer = radioButton.Text;
                        break;
                    }
                }
            }
            selectedTest.answers[currentQuestion].AnswerText = selectedAnswer;
        }

        // Завершення тестування
        private void finishTest()
        {
            // Обчислити кількість правильних відповідей
            int correctAnswers = 0;
            for (int i = 0; i < selectedTest.questions.Count; i++)
            {
                if (selectedTest.answers[i] == selectedTest.questions[i].CorrectAnswer)
                {
                    correctAnswers++;
                }
            }

            // Показати результати тестування
            string message = String.Format("Кількість правильних відповідей: {0} з {1}", correctAnswers, selectedTest.questions.Count);
            MessageBox.Show(message, "Результати тестування", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Зберегти результати тестування у базі даних
            saveResults(correctAnswers);

            // Закрити форму тестування
            this.Close();
        }


        private void saveResults(int correctAnswers)
        {
            // Виконаємо підключення до бази даних
            SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security=True");

            try
            {
                // Відкриваємо підключення до бази даних
                connection.Open();

                // Формуємо SQL-запит для вставки результатів тестування до таблиці Results
                string query = "INSERT INTO Results (Username, TestName, CorrectAnswers, TotalQuestions, TestDate) VALUES (@username, @testName, @correctAnswers, @totalQuestions, @testDate)";

                // Створюємо об'єкт команди для виконання SQL-запиту
                SqlCommand command = new SqlCommand(query, connection);

                // Додаємо параметри до команди
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@testName", selectedTest);
                command.Parameters.AddWithValue("@correctAnswers", correctAnswers);
                command.Parameters.AddWithValue("@testDate", DateTime.Now);

                // Виконуємо SQL-запит
                command.ExecuteNonQuery();

                // Виводимо повідомлення про успішне збереження результатів тестування
                MessageBox.Show("Результати тестування збережені до бази даних");

                // Очищуємо форму для початку нового тестування
                clearForm();
            }
            catch (Exception ex)
            {
                // Виводимо повідомлення про помилку
                MessageBox.Show("Сталася помилка при збереженні результатів тестування до бази даних: " + ex.Message);
            }
            finally
            {
                // Закриваємо підключення до бази даних
                connection.Close();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void testsListBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (testsListBox.SelectedItem != null)
            {
               selectedTest = testsListBox.SelectedItem as Test;
                // Do something with the selected test, like assign it to a variable
            }
        }

        private void feedbackLabel_Click(object sender, EventArgs e)
        {

        }

        private void answerGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "root" && passwordTextBox.Text == "rootroot")
            {
                MessageBox.Show("Login successful!");
                loginGroupBox.Hide();
            }
            else {
                MessageBox.Show("Login unsuccessful!");
            }
        }
    }

}
