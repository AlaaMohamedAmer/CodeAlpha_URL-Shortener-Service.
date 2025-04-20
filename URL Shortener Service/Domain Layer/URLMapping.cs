namespace URL_Shortener_Service.Domain_Layer
{
	public class URLMapping
	{
		public Guid Id { get; set; }
		public string OriginalCode { get; set; }
		public string ShortCode { get; set; }
		public DateTime CreatredAt { get; set; } = DateTime.Now; 
	}
}
