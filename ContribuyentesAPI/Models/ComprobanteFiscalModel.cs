namespace ContribuyentesAPI.Models
{
    public class ComprobanteFiscalModel
    {
        public int Id { get; set; }
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Monto { get; set; }
        public decimal Itbis18 { get; set; }
    }
}