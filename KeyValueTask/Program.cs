Dictionary<string,DateTime> exams= new Dictionary<string,DateTime>();
exams.Add("Crypto", new DateTime(2024, 11, 11));
exams.Add("VBS", new DateTime(2024, 12, 04));
exams.Add("English", new DateTime(2024, 10, 07));
exams.Add("IKT", new DateTime(2024, 09, 12));

foreach (var exam in exams)
{
    int daysLeft = (exam.Value.Date - DateTime.Now.Date).Days;
    Console.WriteLine($" Exam: {exam.Key}, Date: {exam.Value.Date.ToString("dd.MM.yyyy")} , Days left till exam: {daysLeft}");
}