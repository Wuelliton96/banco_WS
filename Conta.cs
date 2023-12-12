class Conta : banco, Iconta
{
    public Conta()
    {
        this.NumeroAgencia = "0001";
        Conta.NumeroContaSequencial++;
        this.Movimentacoes = new List<Extrato>();
    }
    public double Saldo { get; protected set; }
    public string NumeroAgencia { get; private set; }
    public string NumeroConta { get; protected set;}

    public static int NumeroContaSequencial{get; private set;}
    private List<Extrato> Movimentacoes;
    public double ConsultaSaldo()
    {
        return this.Saldo;
    }

    public void Deposita(double valor)
    {
        DateTime dataAtual = DateTime.Now;
        this.Movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor));
        this.Saldo += valor;
    }

    public bool Saca(double valor)
    {
        if(valor > this.ConsultaSaldo())
            return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

        this.Saldo -= valor;
        return true;
    }

    public string GetCodigoDoBanco()
    {
        return CodigoDoBanco;
    }

    public string GetNumeroAgencia()
    {
        return NumeroAgencia;
    }

    public string GetNumeroDaConta()
    {
        return NumeroConta;
    }

    public List<Extrato> Extrato()
    {
        return this.Movimentacoes;
    }
}