using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlashCard.View.TrangChu
{
    public partial class Kiemtra : UserControl
    {
        private List<Question> allQuestions; // Danh sách toàn bộ câu hỏi
        private List<Question> filteredQuestions; // Danh sách câu hỏi đã lọc
        private List<string> topics; // Danh sách chủ đề
        private int currentQuestionIndex = 0;

        public Kiemtra()
        {
            InitializeComponent();
            allQuestions = new List<Question>();
            filteredQuestions = new List<Question>();
            topics = new List<string>();
            LoadTopics(); // Tải chủ đề mẫu
            LoadQuestions(); // Tải câu hỏi

            // Đăng ký sự kiện cho các RadioButton
            rdoMultipleChoice.CheckedChanged += rdoMultipleChoice_CheckedChanged;
            rdoFillInTheBlank.CheckedChanged += rdoFillInTheBlank_CheckedChanged;
            rdoMixed.CheckedChanged += rdoMixed_CheckedChanged;
        }

        // Hàm để tải chủ đề
        private void LoadTopics()
        {
            topics.Add("Nature");
            topics.Add("Science");
            topics.Add("History");
            topics.Add("Technology");

            foreach (var topic in topics)
            {
                clbTopics.Items.Add(topic);
            }
        }

        // Hàm để tải câu hỏi
        private void LoadQuestions()
        {
            allQuestions.Add(new Question
            {
                Text = "What is the ocean?",
                AnswerChoices = new List<string>
                {
                    "The quality of continuing steadily despite difficulties.",
                    "A vast body of salt water that covers most of the earth.",
                    "A shape with three sides and three angles.",
                    "A two-wheeled vehicle powered by pedaling."
                },
                CorrectAnswer = "A vast body of salt water that covers most of the earth.",
                Topic = "Nature"
            });

            allQuestions.Add(new Question
            {
                Text = "What is a computer?",
                AnswerChoices = new List<string>
                {
                    "A device used to process data.",
                    "An animal living in the wild.",
                    "A large landmass on Earth.",
                    "A type of historical document."
                },
                CorrectAnswer = "A device used to process data.",
                Topic = "Technology"
            });

            filteredQuestions = allQuestions;
            LoadQuestion();
        }

        // Hàm hiển thị câu hỏi trắc nghiệm
        private void LoadMultipleChoiceQuestion()
        {
            if (filteredQuestions.Count == 0) return;

            var question = filteredQuestions[currentQuestionIndex];
            lblQuestion.Text = question.Text;

            rdoAnswer1.Visible = true;
            rdoAnswer2.Visible = true;
            rdoAnswer3.Visible = true;
            rdoAnswer4.Visible = true;

            rdoAnswer1.Text = question.AnswerChoices[0];
            rdoAnswer2.Text = question.AnswerChoices[1];
            rdoAnswer3.Text = question.AnswerChoices[2];
            rdoAnswer4.Text = question.AnswerChoices[3];

            lblResult.Text = "";
        }

        // Hàm hiển thị câu hỏi điền từ
        private void LoadFillInTheBlankQuestion()
        {
            if (filteredQuestions.Count == 0) return;

            var question = filteredQuestions[currentQuestionIndex];
            lblQuestion.Text = question.Text;

            rdoAnswer1.Visible = false;
            rdoAnswer2.Visible = false;
            rdoAnswer3.Visible = false;
            rdoAnswer4.Visible = false;

            txtAnswer.Visible = true; // Hiển thị TextBox để nhập câu trả lời
            lblResult.Text = "";
        }

        // Hàm hiển thị câu hỏi
        private void LoadQuestion()
        {
            if (rdoMultipleChoice.Checked)
            {
                LoadMultipleChoiceQuestion();
            }
            else if (rdoFillInTheBlank.Checked)
            {
                LoadFillInTheBlankQuestion();
            }
            // Nếu là chế độ tổng hợp, bạn có thể tùy chỉnh theo yêu cầu
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var question = filteredQuestions[currentQuestionIndex];
            string selectedAnswer = "";

            if (rdoMultipleChoice.Checked)
            {
                if (rdoAnswer1.Checked) selectedAnswer = rdoAnswer1.Text;
                else if (rdoAnswer2.Checked) selectedAnswer = rdoAnswer2.Text;
                else if (rdoAnswer3.Checked) selectedAnswer = rdoAnswer3.Text;
                else if (rdoAnswer4.Checked) selectedAnswer = rdoAnswer4.Text;
            }
            else if (rdoFillInTheBlank.Checked)
            {
                selectedAnswer = txtAnswer.Text.Trim();
            }

            if (selectedAnswer == question.CorrectAnswer)
            {
                lblResult.Text = "Đúng!";
            }
            else
            {
                lblResult.Text = "Sai rồi!";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentQuestionIndex++;
            if (currentQuestionIndex < filteredQuestions.Count)
            {
                LoadQuestion();
            }
            else
            {
                MessageBox.Show("Bạn đã hoàn thành bài kiểm tra!");
                currentQuestionIndex = 0;
                LoadQuestion();
            }
        }

        // Sự kiện chuyển sang chế độ Trắc nghiệm
        private void rdoMultipleChoice_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMultipleChoice.Checked)
            {
                txtAnswer.Visible = false;
                LoadMultipleChoiceQuestion();
            }
        }

        // Sự kiện chuyển sang chế độ Điền từ
        private void rdoFillInTheBlank_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFillInTheBlank.Checked)
            {
                txtAnswer.Visible = true;
                LoadFillInTheBlankQuestion();
            }
        }

        // Sự kiện chuyển sang chế độ Tổng hợp
        private void rdoMixed_CheckedChanged(object sender, EventArgs e)
        {
            // Bạn có thể tùy chỉnh chế độ này nếu cần
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> AnswerChoices { get; set; }
        public string CorrectAnswer { get; set; }
        public string Topic { get; set; }
    }
}
