class Layout
{
    private static List<Pessoa> pessoas = new List<Pessoa>();
    private static int opcao = 0;

    public static void TelaPrincipal()
    {   

        //Cor para a tela
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.Clear();
        //Criaçlão da tela
        Console.WriteLine("   Seja bem vindo ao banco manseira  ");
        Console.WriteLine("                                     ");
        Console.WriteLine("      Digite a Opção desejada :      ");
        Console.WriteLine("    ==============================   ");
        Console.WriteLine("      1- Criar conta                 ");
        Console.WriteLine("    ==============================   ");
        Console.WriteLine("      2- Entrar com o CPF e Senha    ");
        Console.WriteLine("    ==============================   ");
        Console.WriteLine("      3- Sair    ");
        Console.WriteLine("    ==============================   ");
           
        opcao = int.Parse(Console.ReadLine());
        //Opção quando escolher o menu
        switch (opcao)
        {
            case 1 :
                TelaCriarConta();
                break;
            case 2 :
                TelaLogin();
                break;
            case 3:
            Console.WriteLine("                                                     ");
                Console.WriteLine("Volte sempre!");
                Thread.Sleep(2000);
                break;
            default:
                Console.WriteLine("Opção inválida, fim de operação!");
                break;
        }

        static void TelaCriarConta()
        {   
            Console.Clear();
            //Criação da conta 
            Console.WriteLine("                                     ");
            Console.WriteLine("      Digite o seu nome:             ");
            string nome =  Console.ReadLine();
            Console.WriteLine("    ==============================   ");
            Console.WriteLine("      Digite o CPF                   ");
            string cpf  =   Console.ReadLine();
            Console.WriteLine("    ==============================   ");
            Console.WriteLine("      Digite sua senha               ");
            string senha = Console.ReadLine();
            Console.WriteLine("    ==============================   ");

            //Criar uma conta

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();
            //Redirecionando para tela do usuario.
            Console.WriteLine("                                      ");
            Console.WriteLine("                                      ");
            Console.WriteLine("     Conta cadastrada com sucesso.    ");
            Console.WriteLine("     Favor aguarde...                 ");
            Console.WriteLine("    ===============================   ");


            //Espera 2 segundo para ir para tela logada
            Thread.Sleep(2000);

            TelaContaLogada(pessoa);

        }

        static void TelaLogin()
        {   
            //Para entrar no banco, após ter cadastro.
            Console.Clear();
            
            Console.WriteLine("                                     ");
            Console.WriteLine("      Digite o CPF :                 ");
            string cpf = Console.ReadLine();
            Console.WriteLine("    ==============================   ");
            Console.WriteLine("      Digite sua Senha:              ");
            string senha = Console.ReadLine();
            Console.WriteLine("    ==============================   ");
             

            //Logar no sistema
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if(pessoa != null)
            {
                //Tela de boas vindas.
                TelaBoasVindas(pessoa);
                //Tela contalogada
                TelaContaLogada(pessoa);
            }
            else
            {
            
            }
            
            TelaSemcadastro();
            
        }

        static void TelaSemcadastro()
        {
                Console.Clear();
                Console.WriteLine("                                                     ");
                Console.WriteLine("      ======================================         ");
                Console.WriteLine("        Conta não cadastrada!                        ");
                Console.WriteLine("      ======================================         ");
                Console.WriteLine("        1 - Deseja Criar uma nova conta?             ");
                Console.WriteLine("      ======================================         ");
                Console.WriteLine("        2 - Sair.                                    ");
                Console.WriteLine("      ======================================         ");
                
                opcao = int.Parse(Console.ReadLine());
                switch(opcao)
                {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    Console.WriteLine("                                                     ");
                    Console.WriteLine("Até maiss...");
                    break;
                    
                }
        }
        static void TelaBoasVindas(Pessoa pessoa)
        {   
            //Dados de cadastro da conta
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("                                                      ");
            Console.WriteLine($"  Seja bem vindo, {pessoa.Nome}");
            Console.WriteLine($"  Banco: {pessoa.Conta.GetCodigoDoBanco()}, Banco Manseira.");
            Console.WriteLine($"  Agencia: {pessoa.Conta.GetNumeroAgencia()}");
            Console.WriteLine($"  Conta : {pessoa.Conta.GetNumeroDaConta()}");
            Console.WriteLine("______________________________________________________");
        }

        static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);
            //Tela de opção para acesso
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("               Digite a opção desejada:              ");
            Console.WriteLine("              ===========================            ");
            Console.WriteLine("               1-Realizar um deposito                ");
            Console.WriteLine("              ===========================            ");
            Console.WriteLine("               2-Realizar um saque                   ");
            Console.WriteLine("              ===========================            ");
            Console.WriteLine("               3-Consultar Saldo                     ");
            Console.WriteLine("              ===========================            ");
            Console.WriteLine("               4-Extrato                             ");
            Console.WriteLine("              ===========================            ");
            Console.WriteLine("               5- Sair                               ");
            Console.WriteLine("              ===========================            ");

            opcao = int.Parse(Console.ReadLine());
            //
            switch(opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                                                     ");
                    Console.WriteLine("                                                     ");
                    Console.WriteLine("              Opção Inválida!                        ");
                    Console.WriteLine("              ===========================            ");

                    break;
                
            }
        }

        static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);
            //Deposito
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("           Digite o valor do deposito:                ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("       =================================              ");

            pessoa.Conta.Deposita(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);
            //Confirmação de deposito
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("        Deposito Realizado com sucesso!              ");
            Console.WriteLine("       =================================             ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                      ");

            OpcaoVoltarLogado(pessoa);
        }

        static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);
            //Confirmação de Saque
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("           Digite o valor do Saque :                  ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("       =================================              ");

            bool okSaque = pessoa.Conta.Saca(valor);

            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                      ");
            Console.WriteLine("                                                      ");
            //Mensagem
            if(okSaque)
            {
                Console.WriteLine("                                                      ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("        Saque foi Realizado com sucesso!              ");
                Console.WriteLine("        =================================             ");
            }
            else
            {   
                Console.WriteLine("                                                      ");
                Console.WriteLine("                                                      ");
                Console.WriteLine("        Saldo insuficiente!                           ");
                Console.WriteLine("        =================================             ");
            }
            
            Console.WriteLine("                                                      ");
            Console.WriteLine("                                                      ");

            OpcaoVoltarLogado(pessoa);
        }

        static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            //Mensagem
            TelaBoasVindas(pessoa);
            Console.WriteLine("                                                           ");
            Console.WriteLine("                                                           ");                
            Console.WriteLine($"         Seu Saldo é : {pessoa.Conta.ConsultaSaldo()}     ");
            Console.WriteLine("        ======================================             ");
            Console.WriteLine("                                                           ");

            OpcaoVoltarLogado(pessoa);
        }
        static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            if(pessoa.Conta.Extrato().Any())
            {
                //Mostrar Extrato
                double total =  pessoa.Conta.Extrato().Sum(x=>x.Valor);
                
                foreach(Extrato extrato in pessoa.Conta.Extrato())
                {  
                    Console.WriteLine("                                                      ");
                    Console.WriteLine($"      Tipo de Movimentação: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}      ");
                    Console.WriteLine($"      Tipo de Movimentação: {extrato.Descricao}      ");
                    Console.WriteLine($"      Tipo de Movimentação: {extrato.Valor}          ");
                    Console.WriteLine("      =======================================         ");

                }
                Console.WriteLine("                                                     ");
                Console.WriteLine($"               Sub total: {total}                    ");
                Console.WriteLine("      =======================================         ");

            }
            else
            {
                //Monstar uma mensagem que não há extrato
                Console.WriteLine("                                                     ");
                Console.WriteLine("        Não há extrato a ser exibido!                ");
                Console.WriteLine("       =================================             ");
            }
            

            OpcaoVoltarLogado(pessoa);
        }
        static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("        Entre com uma opção abaixo.                  ");
            Console.WriteLine("       =================================             ");
            Console.WriteLine("        1 - Voltar para minha conta                  ");
            Console.WriteLine("       =================================             ");
            Console.WriteLine("        2 - Sair                                     ");
            Console.WriteLine("       =================================             ");

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
                TelaContaLogada(pessoa);
            else
                TelaPrincipal();
                
        }

        static void OpcaoVoltarDeslogada(Pessoa pessoa)
        {  
            Console.WriteLine("                                                        ");
            Console.WriteLine("        Entre com uma opção abaixo.                     ");
            Console.WriteLine("       =================================                ");
            Console.WriteLine("        1 - Voltar para menu principal                  ");
            Console.WriteLine("       =================================                ");
            Console.WriteLine("        2 - Sair                                        ");
            Console.WriteLine("       =================================                ");

            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
                TelaPrincipal();
            else
            {
                Console.WriteLine("                                                        ");
                Console.WriteLine("               Opção Inváçoda!                          ");
                Console.WriteLine("       =================================                ");
            }
                
        }
    }  
}