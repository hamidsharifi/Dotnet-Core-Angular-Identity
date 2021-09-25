namespace Avery.LabelManager.DAL.Models
{
    public class Report: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public byte[] LayoutData { get; set; }
    }
}
