using System;

namespace GuessTheCard
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] naipes = { "Copas", "Ouros", "Espadas", "Paus" };
            string[] valores = { "Ás", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Valete", "Dama", "Rei" };
            Random random = new Random();

            string cartaSecreta = $"{valores[random.Next(valores.Length)]} de {naipes[random.Next(naipes.Length)]}";
            int tentativas = 0;
            string palpite = "";

            // Mapeia os valores para comparação
            int valorSecreto = GetValor(cartaSecreta.Split(' ')[0]);
            string naipeSecreto = cartaSecreta.Split(' ')[2];
            int pontasSecreto = GetPontas(naipeSecreto);

            Console.WriteLine("Bem-vindo ao jogo Adivinhe a Carta!");
            Console.WriteLine("Tente adivinhar a carta que foi escolhida.");

            while (palpite.ToLower() != cartaSecreta.ToLower())
            {
                Console.Write("Digite sua aposta (Ex: Ás de Copas): ");
                palpite = Console.ReadLine();
                tentativas++;

                int valorPalpite = GetValor(palpite.Split(' ')[0]);
                string naipePalpite = palpite.Split(' ')[2];

                // Verifica se acerto
                if (palpite.ToLower() == cartaSecreta.ToLower())
                {
                    Console.WriteLine($"Parabéns! Você adivinhou a carta '{cartaSecreta}' em {tentativas} tentativas!");
                }
                else
                {
                    // Feedback sobre o naipe e valor
                    if (valorPalpite == valorSecreto && naipePalpite.ToLower() != naipeSecreto.ToLower())
                    {
                        Console.WriteLine($"Você acertou o valor '{valorPalpite}', mas errou o naipe.");
                        Console.WriteLine($"Dica: O formato do naipe tem {pontasSecreto} pontas.");
                    }
                    else if (naipePalpite.ToLower() == naipeSecreto.ToLower() && valorPalpite != valorSecreto)
                    {
                        Console.WriteLine($"Você acertou o naipe '{naipePalpite}', mas errou o valor.");
                        Console.WriteLine($"Dica: Seu palpite é {(valorPalpite < valorSecreto ? "baixo" : "alto")}!");
                    }
                    else
                    {
                        Console.WriteLine("Errado! Tente novamente.");
                        // Dicas sobre baixo ou alto
                        if (valorPalpite < valorSecreto)
                        {
                            Console.WriteLine("Dica: Seu palpite é baixo!");
                        }
                        else if (valorPalpite > valorSecreto)
                        {
                            Console.WriteLine("Dica: Seu palpite é alto!");
                        }
                        // Dica sobre o formato do naipe
                        if (GetPontas(naipePalpite) != pontasSecreto)
                        {
                            Console.WriteLine($"Dica: O formato do naipe tem {pontasSecreto} pontas.");
                        }
                    }
                }
            }

            Console.WriteLine("Obrigado por jogar!");
        }

        static int GetValor(string valor)
        {
            return valor switch
            {
                "Ás" => 1,
                "2" => 2,
                "3" => 3,
                "4" => 4,
                "5" => 5,
                "6" => 6,
                "7" => 7,
                "8" => 8,
                "9" => 9,
                "10" => 10,
                "Valete" => 11,
                "Dama" => 12,
                "Rei" => 13,
                _ => 0, // Caso o valor não seja reconhecido
            };
        }

        static int GetPontas(string naipe)
        {
            return naipe switch
            {
                "Copas" => 1,   // Forma de coração
                "Ouros" => 1,    // Forma de diamante
                "Espadas" => 2,  // Forma de espada
                "Paus" => 3,     // Forma de trevo
                _ => 0,          // Naipe desconhecido
            };
        }
    }
}
