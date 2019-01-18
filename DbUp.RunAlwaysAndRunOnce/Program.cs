using DbUp.Engine;
using DbUp.Support;

namespace DbUp.RunAlwaysAndRunOnce
{
    public class Program
    {
        private static readonly string Namespace = typeof(Program).Namespace;
        private static readonly string SchemaChangesScriptsPrefix = $"{Namespace}.SchemaChanges";
        private static readonly string ObjectsScriptsPrefix = $"{Namespace}.Objects";

        public static void Main(string[] args)
        {
            var thisAssembly = typeof(Program).Assembly;

            var upgrader = DeployChanges
                .To.SqlDatabase(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=DbUp.RunAlwaysAndRunOnce; Integrated Security=SSPI")
                .WithScriptsEmbeddedInAssembly(
                    thisAssembly,
                    scriptName => scriptName.StartsWith(SchemaChangesScriptsPrefix),
                    new SqlScriptOptions
                    {
                        RunGroupOrder = 1,
                        ScriptType = ScriptType.RunOnce
                    })
                .WithScriptsEmbeddedInAssembly(
                    thisAssembly,
                    scriptName => scriptName.StartsWith(ObjectsScriptsPrefix),
                    new SqlScriptOptions
                    {
                        RunGroupOrder = 2,
                        ScriptType = ScriptType.RunAlways
                    })
                .LogToConsole()
                .LogToTrace()
                .Build();

            upgrader.PerformUpgrade();
        }
    }
}
