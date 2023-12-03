public class Authenticator
{

    private static string InputUsername()
    {
        while (true) // TODO: unloop
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine()!;
            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                Console.WriteLine("Username is required!");
                // TODO: remove console log and return null
            }
            return username;
        }
    }

    private static string InputPassword()
    {
        while (true) // TODO: unloop
        {
            Console.Write("Enter password: ");
            string password = Console.ReadLine()!;
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Password is required!");
                // TODO: remove console log and return null
            }
            else return password;
        }
        // TODO: mask password
    }
    public static (bool, string, string) AuthenticateUser()
    {



        string inputUsername = InputUsername();
        string inputPassword = InputPassword();

        string loginUsername = Environment.credentials["username"];
        string loginPassword = Environment.credentials["password"];

        (bool isAuthenticated, string username, string password) login = (false, inputUsername, inputPassword);

        // SUGGESTION: handle multiple users

        if (inputUsername != loginUsername || inputPassword != loginPassword)
            Console.WriteLine("Invalid username or password!");

        if (inputUsername == loginUsername && inputPassword == loginPassword)
            login.isAuthenticated = true;

        return login;
    }
}


/**

each prompt (username and password) is enclosed
in a while loop which i think is unnecessary

this however allows the user to enter only the field that 
has no value and skip returning back from the beginning

i think it's better to remove these while loops and
return to the main menu unstead to repeat the login process

*/