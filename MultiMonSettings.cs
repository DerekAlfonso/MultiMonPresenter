using System.Text.Json;

namespace MultiMonPresenter
{
    public class MultiMonSettings
    {
        public static MultiMonSettings Load(string? filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return new MultiMonSettings();
            }
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<MultiMonSettings>(json) ?? new MultiMonSettings();
        }
        public string FilePath { get; set; } = "";
        public List<int> SelectedMonitors { get; set; } = new List<int>();
        public void Save(string filePath)
        {
            var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
