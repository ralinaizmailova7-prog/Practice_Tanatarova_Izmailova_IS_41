using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

string connectionString = "Server=192.168.227.14;Port=3306;Database=tradeddr;Uid=user07;Pwd=User07!Pass;";

app.MapGet("/notes", () =>
{
    try
    {
        var notesList = new List<object>();

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = @"
                SELECT n.id, n.title, n.content, n.created_at, u.login
                FROM notes n
                JOIN Пользователи u ON u.id = n.id_user";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string id = reader["id"].ToString();
                string title = reader["title"].ToString();
                string content = reader["content"].ToString();
                string login = reader["login"].ToString();
                DateTime createdAt = Convert.ToDateTime(reader["created_at"]);
                notesList.Add(new
                {
                    id = id,
                    title_user = $"{title} - {login}",
                    content = content,
                    formatted_date = createdAt.ToString("dd.MM.yyyy")
                });
            }
        }
        return Results.Ok(notesList);
    }
    catch (Exception ex)
    {
        return Results.Json(new { error = "Ошибка подключения к базе данных: " + ex.Message }, statusCode: 500);
    }
});

app.Run();
app.Run();
