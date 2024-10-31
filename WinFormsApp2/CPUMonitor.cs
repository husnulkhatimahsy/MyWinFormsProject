using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class CPUMonitor
{
    private PerformanceCounter cpuCounter;
    private bool isMonitoring;
    private double totalCpuUsage;
    private int sampleCount;

    public CPUMonitor()
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
    }

    public double GetAverageCpuUsage()
    {
        return sampleCount > 0 ? totalCpuUsage / sampleCount : 0;
    }

    public void Reset()
    {
        totalCpuUsage = 0;
        sampleCount = 0;
    }

    private void MonitorCpuUsage()
    {
        while (isMonitoring)
        {
            double currentCpuUsage = cpuCounter.NextValue();
            totalCpuUsage += currentCpuUsage;
            sampleCount++;
            Thread.Sleep(500); // Interval pengambilan sampel setiap 500 ms
        }
    }
}