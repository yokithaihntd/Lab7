using Microsoft.EntityFrameworkCore;
using Lab7.Entity;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private DataContext _context;
        public Form1()
        {
            InitializeComponent();
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filmBindingSource.DataSource = _context.Film.Local.ToBindingList();
            _context.Film.Load();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string title = txtBoxTitle.Text;
            string director = txtBoxDirector.Text;
            string writer = txtBoxWriter.Text;
            string genre = txtBoxGenre.Text;

            int year;
            if (int.TryParse(txtBoxYear.Text, out year))
            {
                Film newFilm = new Film(title, director, writer, genre, year);

                _context.Film.Add(newFilm);
                _context.SaveChanges();

                filmBindingSource.DataSource = _context.Film.Local.ToBindingList();
            }
            else
            {
                MessageBox.Show("Неверный формат года.");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewFilms.SelectedRows.Count > 0)
            {
                int selectedId = (int)dataGridViewFilms.SelectedRows[0].Cells[0].Value;
                var filmToDelete = _context.Film.Find(selectedId);

                if (filmToDelete != null)
                {
                    _context.Film.Remove(filmToDelete);
                    _context.SaveChanges();
                    filmBindingSource.RemoveCurrent();
                }
            }
        }

        private void dataGridViewFilms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
