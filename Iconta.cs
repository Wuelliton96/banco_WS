interface Iconta
{
        void Deposita (double valor);
        bool Saca (double valor);
        double ConsultaSaldo();
        string GetCodigoDoBanco();
        string GetNumeroAgencia();
        string GetNumeroDaConta();
        List<Extrato> Extrato();
}