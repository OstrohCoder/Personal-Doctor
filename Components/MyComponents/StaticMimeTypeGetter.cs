namespace Personal_Doctor.Components.MyComponents
{
    public static class StaticMimeTypeGetter
    {
        public static string GetImageSrc(byte[] imageData)
        {
            return $"data:{GetMimeType(imageData)};base64,{Convert.ToBase64String(imageData)}";
        }

        public static string GetMimeType(byte[] imageData)
        {
            if (imageData == null || imageData.Length < 4)
                return "application/octet-stream";

            // SVG
            string header = System.Text.Encoding.UTF8.GetString(imageData, 0, Math.Min(imageData.Length, 100)).ToLowerInvariant();
            if (header.Contains("<svg") || header.Contains("<?xml"))
                return "image/svg+xml";

            // PNG
            if (imageData[0] == 0x89 && imageData[1] == 0x50 && imageData[2] == 0x4E && imageData[3] == 0x47)
                return "image/png";

            // JPEG
            if (imageData[0] == 0xFF && imageData[1] == 0xD8)
                return "image/jpeg";

            // GIF
            if (imageData[0] == 0x47 && imageData[1] == 0x49 && imageData[2] == 0x46)
                return "image/gif";

            // WEBP
            if (imageData[0] == 0x52 && imageData[1] == 0x49 && imageData[2] == 0x46 && imageData[8] == 0x57)
                return "image/webp";

            return "application/octet-stream";
        }
    }
}
