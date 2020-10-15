using System;
using System.Linq;
using System.Threading;
using PokemonGame.DataProviders;
using PokemonGame.DependencyInjection.Attributes;
using PokemonGame.Extensions;
using PokemonGame.Models;

namespace PokemonGame
{
    /// <summary>
    /// Controls the execution of the game.
    /// </summary>
    public class Game : IDisposable
    {
        /// <summary>
        /// Gets or sets the instance of <see cref="IPokemonFactory"/>
        /// used for spawning Pokémons.
        /// </summary>
        [Dependency]
        public IPokemonFactory PokemonFactory { get; set; }

        /// <summary>
        /// Gets or sets the instance of <see cref="IPokemonTemplates"/>
        /// used for getting Pokémon templates.
        /// </summary>
        [Dependency]
        public IPokemonTemplates PokemonTemplates { get; set; }

        /// <summary>
        /// Gets or sets the instance of <see cref="IRandomNumberGenerator"/>
        /// used for generating random numbers.
        /// </summary>
        [Dependency]
        public IRandomNumberGenerator RandomNumberGenerator { get; set; }

        /// <summary>
        /// Gets or sets the instance of <see cref="ISkills"/>
        /// used for getting skills.
        /// </summary>
        [Dependency]
        public ISkills Skills { get; set; }

        /// <summary>
        /// Executes the logic associated to the game.
        /// </summary>
        public void Run()
        {
            if (!PokemonTemplates.AllEntities.Any())
            {
                Console.WriteLine("[Error] There are no Pokémon templates due to which it is impossible to spawn Pokémons.");
                return;
            }

            var playerTemplate = GetPlayerTemplate();
            var enemyTemplate = GetEnemyTemplate(playerTemplate);

            var player = PokemonFactory.CreateFrom(playerTemplate);
            var enemy = PokemonFactory.CreateFrom(enemyTemplate);
            Console.WriteLine($"Challenger {player.Name} (HP: {player.Health}) versus champion {enemy.Name} (HP: {enemy.Health}).");
            for (var round = 0; player.Health > 0 && enemy.Health > 0; round++)
            {
                Action<Pokemon, Pokemon> action = round % 2 == 0 ? OnPlayerTurn : OnEnemyTurn;
                action(player, enemy);
            }
            Console.WriteLine($"{(player.Health > 0 ? player.Name : enemy.Name)} is victorious.");
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Console.WriteLine("[Debug] Not much to clean up here.");
        }

        private PokemonTemplate GetPlayerTemplate()
        {
            Console.WriteLine($"Choose your Pokémon: {string.Join(", ", PokemonTemplates.AllEntities.Select(template => template.Name))}");
            PokemonTemplate playerTemplate = null;
            while (!PokemonTemplates.TryGet(Console.ReadLine(), out playerTemplate))
            {
                Console.WriteLine($"The Pokémon you have chosen doesn't exist. Please, choose one from the following list:{Environment.NewLine}"
                                  + $"{string.Join(", ", PokemonTemplates.AllEntities.Select(template => template.Name))}");
            }
            Console.WriteLine($"Your chosen Pokémon is {playerTemplate.Name}.");

            return playerTemplate;
        }

        private PokemonTemplate GetEnemyTemplate(PokemonTemplate playerTemplate)
        {
            var pokemonTemplates = PokemonTemplates.AllEntities.AsArray();
            var enemyTemplateIndex = RandomNumberGenerator.NextInteger(max: pokemonTemplates.Length);
            var enemyTemplate = pokemonTemplates[enemyTemplateIndex];
            if (enemyTemplate.Name == playerTemplate.Name)
            {
                enemyTemplate = pokemonTemplates[(enemyTemplateIndex + 1) % pokemonTemplates.Length];
            }
            Console.WriteLine($"The enemy Pokémon is {enemyTemplate.Name}.");

            return enemyTemplate;
        }

        private void OnPlayerTurn(Pokemon player, Pokemon enemy)
        {
            Console.WriteLine("Choose one of the following actions:");
            Console.Write("0 - Attack");
            var template = PokemonTemplates.Get(player.Name);
            for (var skillIndex = 0; skillIndex < template.Skills.Length; skillIndex++)
            {
                Console.Write($" | {skillIndex + 1} - {template.Skills[skillIndex]}");
            }
            Console.WriteLine();

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > template.Skills.Length)
            {
                Console.WriteLine("Invalid action. Please, see above the valid actions.");
            }

            if (choice == 0)
            {
                Attack(player, enemy);
                return;
            }

            UseSkill(player, enemy, template.Skills[choice - 1]);
        }

        private void OnEnemyTurn(Pokemon player, Pokemon enemy)
        {
            var thinkingTime = RandomNumberGenerator.NextInteger(1000, 3000);
            if (thinkingTime > 2000)
            {
                Console.WriteLine("The enemy is thinking hard...");
            }

            Thread.Sleep(thinkingTime);
            var isSkill = RandomNumberGenerator.NextDouble() < 0.3d;
            if (!isSkill)
            {
                Attack(enemy, player);
                return;
            }

            var template = PokemonTemplates.Get(enemy.Name);
            UseSkill(enemy, player, template.Skills[RandomNumberGenerator.NextInteger(max: template.Skills.Length)]);
        }

        private void Attack(Pokemon attacker, Pokemon defender)
        {
            var damage = (int)(attacker.Attack * RandomNumberGenerator.NextDouble());
            if (damage == 0)
            {
                Console.WriteLine($"{attacker.Name} attacks {defender.Name}, but {defender.Name} evades it.");
                return;
            }

            defender.Health -= damage;
            Console.WriteLine($"{attacker.Name} attacks {defender.Name}, dealing {damage} damage."
                              + $" {defender.Name} has {defender.Health} health points left.");
        }

        private void UseSkill(Pokemon attacker, Pokemon defender, string skillName)
        {
            var skill = Skills.Get(skillName);
            var damage = (int)((attacker.Attack + skill.Attack) * RandomNumberGenerator.NextDouble());
            if (damage == 0)
            {
                Console.WriteLine($"{attacker.Name} uses {skillName} on {defender.Name}, but {defender.Name} evades it.");
                return;
            }

            defender.Health -= damage;
            Console.WriteLine($"{attacker.Name} uses {skillName} on {defender.Name}, dealing {damage} damage."
                              + $" {defender.Name} has {defender.Health} health points left.");
        }
    }
}