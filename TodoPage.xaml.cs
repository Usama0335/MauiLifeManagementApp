using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class TodoPage : ContentPage
    {
        public ObservableCollection<TodoItem> Todos { get; set; }

        public TodoPage()
        {
            InitializeComponent();
            Todos = new ObservableCollection<TodoItem>();
            TodoCollectionView.ItemsSource = Todos;
        }

        private void OnAddTodoClicked(object sender, EventArgs e)
        {
            string title = NewTodoEntry.Text?.Trim();
            if (!string.IsNullOrEmpty(title))
            {
                Todos.Add(new TodoItem { Title = title, IsCompleted = false });
                NewTodoEntry.Text = string.Empty;
            }
        }

        private void OnCompleteTodoClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var todoItem = (TodoItem)button.BindingContext;

            if (todoItem != null)
            {
                todoItem.IsCompleted = !todoItem.IsCompleted;
            }
        }

        private void OnDeleteTodoClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var todoItem = (TodoItem)button.BindingContext;

            if (todoItem != null && Todos.Contains(todoItem))
            {
                Todos.Remove(todoItem);
            }
        }
    }
}
