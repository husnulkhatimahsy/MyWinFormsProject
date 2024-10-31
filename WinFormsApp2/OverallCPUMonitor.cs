using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class OverallCPUMonitor
{
    private PerformanceCounter cpuCounter;
    private bool isMonitoring;
    private double totalCpuUsage;
    private int sampleCount;
    private string logFilePath = @"D:\Skripsi\File\Python\Pengujian\OverallCpuUsageLog.txt";

    public OverallCPUMonitor()
    {
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        totalCpuUsage = 0;
        sampleCount = 0;
    }

    public void StartMonitoring()
    {
        isMonitoring = true;
        Task.Run(() => MonitorCpuUsage());
    }

    public void StopMonitoring()
    {
        isMonitoring = false;

        // Menghitung rata-rata penggunaan CPU
        double averageCpuUsage = sampleCount > 0 ? totalCpuUsage / sampleCount : 0;

        // Menyimpan rata-rata ke file
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine();
                writer.WriteLine($"Rata-rata penggunaan CPU selama aplikasi berjalan: {averageCpuUsage:F2}%");
                writer.WriteLine($"Waktu berhenti monitoring: {DateTime.Now}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal menyimpan rata-rata penggunaan CPU: {ex.Message}");
        }
    }

    private void MonitorCpuUsage()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Monitoring CPU dimulai pada {DateTime.Now}");
                writer.WriteLine();

                while (isMonitoring)
                {
                    double currentCpuUsage = cpuCounter.NextValue();
                    totalCpuUsage += currentCpuUsage;
                    sampleCount++;
                    writer.WriteLine($"[{DateTime.Now}] Penggunaan CPU: {currentCpuUsage:F2}%");
                    Thread.Sleep(500); // Interval pengambilan sampel setiap 500 ms
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Gagal menulis penggunaan CPU ke file: {ex.Message}");
        }
    }
}