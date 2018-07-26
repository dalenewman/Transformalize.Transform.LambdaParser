using Autofac;
using Transformalize.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;
using Transformalize.Containers.Autofac;
using Transformalize.Logging;
using Transformalize.Providers.Bogus.Autofac;
using Transformalize.Transforms.LambdaParser.Autofac;

namespace Benchmark {

    
    [LegacyJitX64Job, LegacyJitX86Job]
    public class Benchmarks {

        [Benchmark(Baseline = true, Description = "500 test rows")]
        public void TestRows() {
            using (var outer = new ConfigurationContainer(new BogusModule(), new LambdaParserModule()).CreateScope(@"files\bogus.xml?Size=500")) {
                using (var inner = new TestContainer(new BogusModule(), new LambdaParserModule()).CreateScope(outer, new NullLogger())) {
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                }
            }
        }

        [Benchmark(Baseline = false, Description = "500 rows with 3 evals")]
        public void CSharpRows() {
            using (var outer = new ConfigurationContainer(new BogusModule(), new LambdaParserModule()).CreateScope(@"files\bogus-lambda-parser.xml?Size=500")) {
                using (var inner = new TestContainer(new BogusModule(), new LambdaParserModule()).CreateScope(outer, new NullLogger())) {
                    var controller = inner.Resolve<IProcessController>();
                    controller.Execute();
                }
            }
        }

    }

    public class Program {
        private static void Main(string[] args) {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
