using System;

public class Program
{
    public static void Main()
    {
        var user = new User();
        var account = new Account();
        IUpdater<Account> updater = new UserService();
        var userService = new UserService();
        userService.Update(user);
    }
}

public class User
{

}

public class Account : User
{

}
public interface IUpdater<in T>
{
    void Update(T entity);
}

public class UserService: IUpdater<User>
{
    public void Update(User entity)
    {
        Console.WriteLine("test");
        Console.Read();
            
    }
}