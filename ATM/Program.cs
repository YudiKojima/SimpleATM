using System;
public class CardHolder
{
    public string CardNumber { get; set; }
    public int SecurityCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Balance { get; set; }

    public CardHolder(string cardNumber, int securityCode, string firstName, string lastName, double balance)
    {
        CardNumber = cardNumber;
        SecurityCode = securityCode;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Escolha uma opção a seguir...");
            Console.WriteLine("1. Depositar");
            Console.WriteLine("2. Sacar");
            Console.WriteLine("3. Exibir saldo");
            Console.WriteLine("4. Sair");
        }

        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("Você deseja depositar quantos reais(R$)?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.Balance += deposit;
            Console.WriteLine("Obrigado por depositar, seu novo saldo é: "
                + currentUser.Balance.ToString("F2"));
        }

        void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("Você deseja sacar quantos R$ ?");
            double withdrawl = double.Parse(Console.ReadLine());
            CalculateWithdrawl(currentUser, withdrawl);
        }

        void Balance(CardHolder currentUser)
        {
            Console.WriteLine("Seu saldo é: " + currentUser.Balance.ToString("F2"));
        }

        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("411111111111", 1234, "Marcos", "Yudi", 150.31));
        cardHolders.Add(new CardHolder("422222222222", 2345, "Kojima", "Silva", 321.13));
        cardHolders.Add(new CardHolder("433333333333", 3456, "Alycia", "Molina", 105.59));
        cardHolders.Add(new CardHolder("444444444444", 4567, "João", "Pedro", 851.84));
        cardHolders.Add(new CardHolder("455555555555", 5678, "Daniel", "Hicaru", 54.27));

        Console.WriteLine("Bem vindo ao ATM Brasil");
        Console.WriteLine("Insira seu cartão de débito: ");
        string debitCardNumber = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.CardNumber == debitCardNumber);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Cartão de débito não reconhecido, Porfavor tente novamente."); }
            }
            catch { Console.WriteLine("Cartão de débito não reconhecido, Porfavor tente novamente.\""); }
        }

        Console.WriteLine("Digite o código de segurança: ");
        int userSecurityCode = 0;

        while (true)
        {
            try
            {
                userSecurityCode = int.Parse(Console.ReadLine());
                if (currentUser.SecurityCode == userSecurityCode) { break; }
                else { Console.WriteLine("Código de segurança incorreta, Porfavor tente novamente."); }
            }
            catch { Console.WriteLine("Código de segurança incorreta, Porfavor tente novamente.\""); }
        }

        Console.WriteLine("Bem vindo " + currentUser.FirstName + ", como está seu dia?");
        int option = 0;

        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { Deposit(currentUser); }
            else if (option == 2) { Withdraw(currentUser); }
            else if (option == 3) { Balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Obrigado por utilizar ATM Brasil, até logo " + currentUser.FirstName + "!");
    }

    private static void CalculateWithdrawl(CardHolder currentUser, double withdrawl)
    {
        // verificar se usuario possui dinheiro que quer retirar
        if (currentUser.Balance > withdrawl)
        {
            currentUser.Balance -= withdrawl;
            Console.WriteLine("Seu saldo atual é: " + currentUser.Balance.ToString("F2"));
            Console.WriteLine("Volte sempre, obrigado!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente...");
        }
    }
}