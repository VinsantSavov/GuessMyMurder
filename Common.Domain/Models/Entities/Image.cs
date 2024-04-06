namespace Common.Domain.Models.Entities
{
    public class Image : BaseModel<int>
    {
        internal Image(
            byte[] originalContent,
            byte[] thumbnailContent)
        {
            OriginalContent = originalContent;
            ThumbnailContent = thumbnailContent;
        }

        public byte[] OriginalContent { get; }

        public byte[] ThumbnailContent { get; }
    }
}
