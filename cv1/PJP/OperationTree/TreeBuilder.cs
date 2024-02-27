using System;
using System.Collections.Generic;
using TokenBuilder;

namespace OperationTree {
	
	public class TreeBuilder {
		private List<Token> Tokens { get;} 
		private int _currentTokenIndex;

		private Token CurrentToken { get => (_currentTokenIndex < Tokens.Count) ? Tokens[_currentTokenIndex] : null; }

		public TreeBuilder(List<Token> tokens) {
			Tokens = tokens;
		}

		public void MoveToNextToken() {
			_currentTokenIndex++;
		}

		public bool TryGetTreeResult(ref int result) {
			try {
				result = Build().Calculate();
				return true;
			}
			catch {
				ConsoleColor curr = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("ERROR");
				Console.ForegroundColor = curr;
				return false;
			}
		}
		
		private INode Build() {
			if (CurrentToken == null) {
				throw new Exception("No nodes passed in");
			}
			
			INode result = CalculateExpression();
			
			if (CurrentToken != null) {
				throw new Exception("No nodes passed in");
			}

			return result;
		}

		public INode CalculateExpression() {
			INode result = CalculateTerm();
			while (CurrentToken != null && (CurrentToken.Type == TokenType.PLUS || 
			                                CurrentToken.Type == TokenType.MINUS)) {
				switch (CurrentToken.Type) {
					case TokenType.PLUS: {
						MoveToNextToken();
						 result = new Add {
							NodeLeft = result,
							NodeRight = CalculateTerm()
						};
						break;
					}
					case TokenType.MINUS: {
						MoveToNextToken();
						result = new Subtract {
							NodeLeft = result,
							NodeRight = CalculateTerm()
						};
						break;
					}
					default: {
						throw new Exception($"Unknown Token {CurrentToken.Type}");
					}
				}
			}
			return result;
		}
		
		public INode CalculateTerm() {
			INode result = CalculateFactor();;

			while (CurrentToken != null && (CurrentToken.Type == TokenType.MULTIPLY ||
			                                CurrentToken.Type == TokenType.DEVIDE)) {
				switch (CurrentToken.Type) {
					case TokenType.MULTIPLY: {
						MoveToNextToken();
						result = new Multiply {
							NodeLeft = result,
							NodeRight = CalculateFactor()
						};
						break;
					}
					case TokenType.DEVIDE: {
						MoveToNextToken();
						result = new Multiply {
							NodeLeft = result,
							NodeRight = CalculateFactor()
						};
						break;
					}
					default: {
						throw new Exception($"Unknown Token {CurrentToken.Type}");
					}
				}
			}

			return result;
		}
		
		public INode CalculateFactor() {
			INode result = null;
			switch (CurrentToken.Type) {
				case TokenType.LPAR: {
					MoveToNextToken();
					result = CalculateExpression();
					if (CurrentToken.Type != TokenType.RPAR) {
						throw new Exception("Unclosed par");
					}
					MoveToNextToken();
					break;
				}
				case TokenType.NUM: {
					result = new Number {
						Value = CurrentToken.Value ?? 0
					};
					MoveToNextToken();
					break;
				}
				default: {
					throw new Exception("Wrong Input!");
				}
			}

			return result;
		}
	}
}