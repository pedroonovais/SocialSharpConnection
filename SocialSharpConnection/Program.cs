using library.controller;
using library.Controller;
using library.Model;
using library.utils;

Console.WriteLine("Olá, bem vindo ao Social Sharp Connection!\nSua rede social em CSharp");

var name = InputHelper.GetInputString("Digite seu nome: ");
var age = InputHelper.GetInputInteger("Digite sua idade: ");
var email = InputHelper.GetInputEmail("Digite seu email: ");
var username = InputHelper.GetInputString("Escolha seu nome de usuário: ");

var user = UserController.CreateUser(name, age, email, username);

Console.Clear();
Console.WriteLine("Cadastro criado com sucesso!");


var posts = PostController.CarregarPosts();

while (true)
{
    var menu = "==== MENU ====" +
    "\n1 - Criar post" +
    "\n2 - Visualizar feed" +
    "\n3 - Sair\n";

    var menuChoise = InputHelper.GetInputInteger(menu, 1, 3);

    if (menuChoise == 1)
    {
        Console.Clear();
        Console.WriteLine("==== CRIANDO NOVA POSTAGEM ====");
        var contentNewPost = InputHelper.GetInputString("Digite o conteúdo da sua postagem: ");

        PostController.CriarPost(ref posts, user, contentNewPost);

        Console.Clear();
        Console.WriteLine("Post Criado com sucesso!");
    }
    else if (menuChoise == 2)
    {
        Console.Clear();
        Console.WriteLine("==== FEED ====");

        if (posts.Count == 0)
        {
            Console.WriteLine("Nenhum post encontrado!");
            continue;
        }
        
        foreach (var post in posts)
        {
            Console.WriteLine(post.ToString() + "\n");
        }
    }
    else
    {
        Console.WriteLine("Obrigado por usar o Social Sharp Connection!");
        break;
    }

    
}


