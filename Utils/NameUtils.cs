class NameUtils {
    private static string[] _firstNames = {"Bolt","Spark","Circuit","Byte","Robo","Nano","Quantum","Dynamo","Laser","Plasma","Astro","Cyber","Mech","Titan","Neon","Gear","Photon","Metal","Tech","Chrome","Turbo","Electro","Sonic","Vector","Byte","Pulsar","Blitz","Flux","Omega","Proton","Nova","Quantum","Ion","Zenith","Eclipse","Fusion","Orion","Axion","Zenon","Helix","Axiom","Eon","Nexus","Vortex","Prism","Apex","Xeno","Nebula","Infinity","Arc"};
    private static string[] _lastNames = {"Robotics","Mechanoid","Cybertron","Systems","Innovations","Technologies","Automaton","Dynamics","Innovators","ElectroCorp","Circuits","MechWorks","Dynamics","Quantumix","Synthetics","Droidex","Cyberware","Inc.","Techtronics","Synthex","Rotorics","Cyberware","ElectroTech","Innovatron","Quantumix","Neotech","DynaMech","Synthix","Innovitech","Techtrix","RoboDyne","Synthworks","Automax","Cybernetix","MechSolutions","ElectroSynth","Quantumics","Innovasion","Robotix","MechTrek","SynthiCorp","CyberSolutions","ElectraTech","QuantumWare","Mechanix","DynaWorks","SynthiSys","TechFusion","RoboCore","DynaCraft"};
    
    public static string GetFullName() {
        var rand = new Random();

        return _firstNames[rand.Next(0, _firstNames.Length)] + " " + _lastNames[rand.Next(0, _lastNames.Length)];
    }
}