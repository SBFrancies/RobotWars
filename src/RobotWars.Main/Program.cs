using System;
using System.Collections;
using System.Collections.Generic;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using RobotWars.Main.Command;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Commands;
using RobotWars.Main.Enums;
using RobotWars.Main.Interface;
using RobotWars.Main.Logging;
using RobotWars.Main.Models;

namespace RobotWars.Main
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IObservable<string> _consoleWatcher;

        static void Main(string[] args)
        {
            RegisterServices();
            RegisterObserver();
            new System.Threading.AutoResetEvent(false).WaitOne();
        }

        private static void RegisterObserver()
        {
            _consoleWatcher = Observable
                .Defer(() =>
                    Observable
                        .Start(_serviceProvider.GetService<IReader>().Read)).Repeat().Publish().RefCount();

            IEnumerable<ICommandReader> commandReaders = _serviceProvider.GetServices<ICommandReader>();

            foreach (var reader in commandReaders)
            {
                _consoleWatcher.Subscribe(input => reader.ValidateAndRun(input));
            }
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<ILogger, ConsoleLogger>();
            collection.AddSingleton<IReader, ConsoleReader>();
            collection.AddTransient<IList<IRobot>>(a => new List<IRobot>());
            collection.AddSingleton<IRobotWarsGame, RobotWarsGame>();
            collection.AddTransient<ICommandReader, StartGameCommandReader<StartGameCommand>>();
            collection.AddTransient<ICommandReader, AddRobotCommandReader<AddRobotCommand>>();
            collection.AddTransient<ICommandReader, MoveRobotCommandReader<MoveRobotCommand>>();
            collection.AddTransient<ICommandReader, EndInputCommandReader<EndInputCommand>>();
            collection.AddTransient<ICommandReader, QuitCommandReader<QuitCommand>>();
            collection.AddTransient<StartGameCommand>();
            collection.AddTransient<AddRobotCommand>();
            collection.AddTransient<MoveRobotCommand>();
            collection.AddTransient<EndInputCommand>();
            collection.AddTransient<QuitCommand>();
            collection.AddSingleton<Func<IRobotWarsGame, int, int, Direction, IRobot>>(RobotFactory);

            IRobot RobotFactory(IRobotWarsGame game, int x, int y, Direction direction) => new Robot(game, x, y, direction);

            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}
