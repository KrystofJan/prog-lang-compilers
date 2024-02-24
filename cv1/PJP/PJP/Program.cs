using System;
using System.Collections.Generic;
using OperationTree;
using TokenBuilder;

namespace PJP
{
    internal class Program
    {
        public static void Main(string[] args) {
            int amount = 0;
            string user_amount = Console.ReadLine();
            while (!Int32.TryParse(user_amount, out amount)) {
                Console.WriteLine($"{user_amount} is nor recognized as a number. Please try again.");
                user_amount = Console.ReadLine();
            }

            string[] user_expressions = new string[amount];
            for (int i = 0; i < amount; ++i) {
                user_expressions[i] = Console.ReadLine();
            }
            
            Console.WriteLine("---------Results---------");
            foreach (string user_expression in user_expressions) {
                Tokenizer tokenizer = new Tokenizer(user_expression);

                List<Token> tokens = tokenizer.ParseExpression();

                TreeBuilder treeBuilder = new TreeBuilder(tokens);

                int result = 0;
                if (treeBuilder.TryGetTreeResult(ref result))
                    Console.WriteLine(result);
            }
            Console.WriteLine("---------The-end---------");

        }
    }
}