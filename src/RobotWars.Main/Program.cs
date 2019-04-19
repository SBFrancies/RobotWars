using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Microsoft.Extensions.DependencyInjection;
using RobotWars.Main.Command;
using RobotWars.Main.CommandReaders;
using RobotWars.Main.Commands;
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
            Console.WriteLine("Hello World!");
            RegisterServices();
            RegisterObserver();
            new System.Threading.AutoResetEvent(false).WaitOne();
        }

        private static void RegisterObserver()
        {
            _consoleWatcher = Observable
                .Defer(() =>
                    Observable
                        .Start(Console.ReadLine)).Repeat().Publish().RefCount();

            IRobotWarsGame game = _serviceProvider.GetService<IRobotWarsGame>();

            _consoleWatcher.Subscribe(input => new StartGameCommandReader().ValidateAndRun(new StartGameCommand(game, input)));
            _consoleWatcher.Subscribe(input => new AddRobotCommandReader().ValidateAndRun(new AddRobotCommand(game, input)));
            _consoleWatcher.Subscribe(input => new MoveRobotCommandReader().ValidateAndRun(new MoveRobotCommand(game, input)));
            _consoleWatcher.Subscribe(input => new EndInputCommandReader().ValidateAndRun(new EndInputCommand(game, input)));
            _consoleWatcher.Subscribe(input => new QuitCommandReader().ValidateAndRun(new QuitCommand(input)));
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<ILogger, ConsoleLogger>();
            collection.AddSingleton<IRobotWarsGame, RobotWarsGame>();
            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}
