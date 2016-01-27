namespace _02.Todos.Web
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;

    using _02.Todos.Data;
    using _02.Todos.Data.Migrations;
    using _02.Todos.Models;

    public partial class Todos : System.Web.UI.Page
    {
        private TodosDbContext dbContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TodosDbContext, Configuration>());
            this.dbContext = new TodosDbContext();
        }

        public List<Todo> TodosListView_GetData()
        {
            return this.dbContext.Todos.ToList();
        }

        public void TodosListView_UpdateItem(int id)
        {
            var todo = this.dbContext.Todos.FirstOrDefault(t => t.Id == id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (todo == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }

            TryUpdateModel(todo);

            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
            }
        }

        public void TodosListView_DeleteItem(int id)
        {
            var todo = this.dbContext.Todos.FirstOrDefault(t => t.Id == id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (todo == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            if (ModelState.IsValid)
            {
                this.dbContext.Todos.Remove(todo);
                this.dbContext.SaveChanges();
            }
        }

        public void TodosListView_InsertItem(Todo todo)
        {
            var item = todo;
            var category = this.dbContext.Categories.FirstOrDefault(c => c.Name == item.Category.Name);

            if (category == null)
            {
                var newCategory = new Category() { Name = item.Category.Name };
                item.Category = newCategory;
            }
            else
            {
                item.Category = category;
            }

            item.LastModified = DateTime.Now;
            //item.Category = this.dbContext.Categories.FirstOrDefault();
            this.dbContext.Todos.Add(item);
            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid Todo");
            }
        }
    }
}