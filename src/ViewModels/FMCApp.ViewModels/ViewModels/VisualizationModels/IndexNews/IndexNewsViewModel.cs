namespace FMCApp.Web.Models.ViewModels.VisualizationModels.IndexNews
{
    public class IndexNewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string HtmlContent => this.Content.Replace("\n", "<br />\n");



    }
}
