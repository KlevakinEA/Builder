//cpu, motherboard, ram, ssd/hdd and gpu
using System.Runtime.InteropServices;

Builder builder = new Builder();
builder.SetCPU("Intel", 4, 2, 1000);
builder.SetMotherboard("Smth", 2);
builder.SetRAM("Sm", 16000, 4000, false);
builder.SetStorage("S", 1000, 6000, 5000, true);
builder.SetGPU("RTX4060", 4000, 8000);
Console.WriteLine(builder.Build().Get_Parts());


class Builder
{
    private string[] cpu { get; set; }
    private string[] motherboard { get; set; }
    private string[] ram { get; set; }
    private string[] storage { get; set; }
    private string[] gpu { get; set; }
    public void SetCPU(string Name, int Threads, int Cores, int Hertzs)
    {
        string[] parameters = new string[4];
        parameters[0] = Name;
        parameters[1] = Convert.ToString(Threads);
        parameters[2] = Convert.ToString(Cores);
        parameters[3] = Convert.ToString(Hertzs);
        cpu = parameters;
    }
    public void SetMotherboard(string Name, int PCIE_slots)
    {
        string[] parameters = new string[2];
        parameters[0] = Name;
        parameters[1] = Convert.ToString(PCIE_slots);
        motherboard = parameters;
    }
    public void SetRAM(string Name, int Volume, int Friquency, bool Is_ECC)
    {
        string[] parameters = new string[4];
        parameters[0] = Name;
        parameters[1] = Convert.ToString(Volume);
        parameters[2] = Convert.ToString(Friquency);
        parameters[3] = Convert.ToString(Is_ECC);
        ram = parameters;
    }
    public void SetStorage(string Name, int Volume, int Read_speed, int Write_speed, bool Is_SSD)
    {
        string[] parameters = new string[5];
        parameters[0] = Name;
        parameters[1] = Convert.ToString(Volume);
        parameters[2] = Convert.ToString(Read_speed);
        parameters[3] = Convert.ToString(Write_speed);
        parameters[4] = Convert.ToString(Is_SSD);
        storage = parameters;
    }
    public void SetGPU(string Name, int TFs, int RAM_volume)
    {
        string[] parameters = new string[3];
        parameters[0] = Name;
        parameters[1] = Convert.ToString(TFs);
        parameters[2] = Convert.ToString(RAM_volume);
        gpu = parameters;
    }
    public Computer Build() { return new Computer([new CPU(cpu), new Motherboard(motherboard), new RAM(ram), new Storage(storage), new GPU(gpu)]); }
}


class Computer
{
    private Part[] parts { get; set;}
    internal Computer(Part[] parts) { this.parts = parts; }
    public string Get_Parts()
    {
        string output = "";
        foreach (Part i in parts) { output += i.Get_Specs() + '\n'; }
        return output;
    }
}


abstract class Part
{
    internal string Name { get; private set; }
    internal Part(string[] parameters) { Name = parameters[0]; }
    abstract public string Get_Specs();
}


class CPU: Part
{
    internal int Threads { get; private set; }
    internal int Cores { get; private set; }
    internal int Hertzs { get; private set; }
    internal CPU(string[] parameters): base(parameters)
    {
        Threads = Convert.ToInt32(parameters[1]);
        Cores = Convert.ToInt32(parameters[2]);
        Hertzs = Convert.ToInt32(parameters[3]);
    }
    override public string Get_Specs() { return Name + ' ' + Convert.ToString(Threads) + ' ' + Convert.ToString(Cores) + ' ' + Convert.ToString(Hertzs); }
}


class Motherboard : Part
{
    internal int PCIE_slots { get; private set; }
    internal Motherboard(string[] parameters) : base(parameters)
    {
        PCIE_slots = Convert.ToInt32(parameters[1]);
    }
    override public string Get_Specs() { return Name + ' ' + Convert.ToString(PCIE_slots); }
}


class RAM : Part
{
    internal int Volume { get; private set; }
    internal int Friquency { get; private set; }
    internal bool Is_ECC { get; private set; }
    internal RAM(string[] parameters) : base(parameters)
    {
        Volume = Convert.ToInt32(parameters[1]);
        Friquency = Convert.ToInt32(parameters[2]);
        Is_ECC = Convert.ToBoolean(parameters[3]);
    }
    override public string Get_Specs() { return Name + ' ' + Convert.ToString(Volume) + ' ' + Convert.ToString(Friquency) + ' ' + Convert.ToString(Is_ECC); }
}


class Storage : Part
{
    internal int Volume { get; private set; }
    internal int Read_speed { get; private set; }
    internal int Write_speed { get; private set; }
    internal bool Is_SSD { get; private set; }
    internal Storage(string[] parameters) : base(parameters)
    {
        Volume = Convert.ToInt32(parameters[1]);
        Read_speed = Convert.ToInt32(parameters[2]);
        Write_speed = Convert.ToInt32(parameters[3]);
        Is_SSD = Convert.ToBoolean(parameters[4]);
    }
    override public string Get_Specs() { return Name + ' ' + Convert.ToString(Volume) + ' ' + Convert.ToString(Read_speed) + ' ' + Convert.ToString(Write_speed) + ' ' + Convert.ToString(Is_SSD); }
}


class GPU : Part
{
    internal int TFs { get; private set; }
    internal int RAM_Volume { get; private set; }
    internal GPU(string[] parameters) : base(parameters)
    {
        TFs = Convert.ToInt32(parameters[1]);
        RAM_Volume = Convert.ToInt32(parameters[2]);
    }
    override public string Get_Specs() { return Name + ' ' + Convert.ToString(TFs) + ' ' + Convert.ToString(RAM_Volume); }
}