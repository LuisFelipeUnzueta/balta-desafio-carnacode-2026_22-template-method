// DESAFIO: Sistema de Processamento de Pedidos com Múltiplos Fluxos
// PROBLEMA: Um sistema precisa processar diferentes tipos de pedidos (Online, Atacado, Marketplace)
// onde cada um segue os mesmos passos gerais mas com implementações específicas. O código atual
// duplica a estrutura do algoritmo em cada classe, tornando difícil manter consistência

using System;
using System.Collections.Generic;

namespace DesignPatternChallenge
{
    // Contexto: E-commerce com múltiplos canais de venda
    // Todos seguem mesmo fluxo: validar → calcular → processar pagamento → enviar → notificar
    // Mas cada canal tem suas particularidades
    
    public class OnlineOrderProcessor
    {
        public void ProcessOrder(string customerId, List<string> items, decimal amount)
        {
            Console.WriteLine("\n=== Processando Pedido Online ===");

            // Passo 1: Validação
            Console.WriteLine("[Online] Validando pedido...");
            if (string.IsNullOrEmpty(customerId))
            {
                Console.WriteLine("❌ Cliente inválido");
                return;
            }
            Console.WriteLine("✓ Pedido validado");

            // Passo 2: Verificar estoque
            Console.WriteLine("[Online] Verificando estoque...");
            foreach (var item in items)
            {
                Console.WriteLine($"  → {item}: Disponível");
            }
            Console.WriteLine("✓ Estoque confirmado");

            // Passo 3: Calcular valores (específico de Online)
            Console.WriteLine("[Online] Calculando valores...");
            decimal shipping = 15.00m;
            decimal total = amount + shipping;
            Console.WriteLine($"  → Subtotal: R$ {amount:N2}");
            Console.WriteLine($"  → Frete: R$ {shipping:N2}");
            Console.WriteLine($"  → Total: R$ {total:N2}");

            // Passo 4: Processar pagamento
            Console.WriteLine("[Online] Processando pagamento com cartão...");
            Console.WriteLine("✓ Pagamento aprovado");

            // Passo 5: Separar pedido
            Console.WriteLine("[Online] Separando itens no estoque...");
            Console.WriteLine("✓ Itens separados");

            // Passo 6: Agendar envio
            Console.WriteLine("[Online] Agendando envio via Correios...");
            Console.WriteLine("✓ Envio agendado");

            // Passo 7: Notificar cliente (específico de Online)
            Console.WriteLine("[Online] Enviando email de confirmação...");
            Console.WriteLine("✓ Email enviado");

            Console.WriteLine("\n✅ Pedido online processado com sucesso!");
        }
    }

    public class WholesaleOrderProcessor
    {
        public void ProcessOrder(string companyId, List<string> items, decimal amount)
        {
            Console.WriteLine("\n=== Processando Pedido Atacado ===");

            // Problema: Mesma estrutura do algoritmo, mas código duplicado
            
            // Passo 1: Validação (diferente de Online)
            Console.WriteLine("[Atacado] Validando pedido...");
            if (string.IsNullOrEmpty(companyId))
            {
                Console.WriteLine("❌ Empresa inválida");
                return;
            }
            if (amount < 1000.00m)
            {
                Console.WriteLine("❌ Pedido mínimo de R$ 1.000,00 para atacado");
                return;
            }
            Console.WriteLine("✓ Pedido validado");

            // Passo 2: Verificar estoque (mesmo que Online, mas duplicado)
            Console.WriteLine("[Atacado] Verificando estoque...");
            foreach (var item in items)
            {
                Console.WriteLine($"  → {item}: Disponível");
            }
            Console.WriteLine("✓ Estoque confirmado");

            // Passo 3: Calcular valores (lógica diferente)
            Console.WriteLine("[Atacado] Calculando valores...");
            decimal discount = amount * 0.10m; // 10% desconto atacado
            decimal total = amount - discount;
            Console.WriteLine($"  → Subtotal: R$ {amount:N2}");
            Console.WriteLine($"  → Desconto (10%): -R$ {discount:N2}");
            Console.WriteLine($"  → Total: R$ {total:N2}");

            // Passo 4: Processar pagamento (boleto ao invés de cartão)
            Console.WriteLine("[Atacado] Gerando boleto bancário...");
            Console.WriteLine("✓ Boleto gerado");

            // Passo 5: Separar pedido (mesmo que Online, duplicado)
            Console.WriteLine("[Atacado] Separando itens no estoque...");
            Console.WriteLine("✓ Itens separados");

            // Passo 6: Agendar envio (transportadora ao invés de Correios)
            Console.WriteLine("[Atacado] Agendando coleta com transportadora...");
            Console.WriteLine("✓ Coleta agendada");

            // Passo 7: Notificar (email + telefone)
            Console.WriteLine("[Atacado] Notificando empresa...");
            Console.WriteLine("  → Email enviado");
            Console.WriteLine("  → SMS enviado");
            Console.WriteLine("✓ Notificações enviadas");

            Console.WriteLine("\n✅ Pedido atacado processado com sucesso!");
        }
    }

    public class MarketplaceOrderProcessor
    {
        public void ProcessOrder(string sellerId, List<string> items, decimal amount)
        {
            Console.WriteLine("\n=== Processando Pedido Marketplace ===");

            // Problema: Terceira duplicação da estrutura do algoritmo
            
            // Passo 1: Validação (verifica vendedor)
            Console.WriteLine("[Marketplace] Validando pedido...");
            if (string.IsNullOrEmpty(sellerId))
            {
                Console.WriteLine("❌ Vendedor inválido");
                return;
            }
            Console.WriteLine("✓ Pedido validado");

            // Passo 2: Verificar estoque (duplicado novamente)
            Console.WriteLine("[Marketplace] Verificando estoque...");
            foreach (var item in items)
            {
                Console.WriteLine($"  → {item}: Disponível");
            }
            Console.WriteLine("✓ Estoque confirmado");

            // Passo 3: Calcular valores (inclui comissão)
            Console.WriteLine("[Marketplace] Calculando valores...");
            decimal commission = amount * 0.15m; // 15% comissão
            decimal sellerAmount = amount - commission;
            Console.WriteLine($"  → Valor total: R$ {amount:N2}");
            Console.WriteLine($"  → Comissão (15%): R$ {commission:N2}");
            Console.WriteLine($"  → Repasse vendedor: R$ {sellerAmount:N2}");

            // Passo 4: Processar pagamento (split payment)
            Console.WriteLine("[Marketplace] Processando split payment...");
            Console.WriteLine($"  → R$ {commission:N2} para marketplace");
            Console.WriteLine($"  → R$ {sellerAmount:N2} para vendedor");
            Console.WriteLine("✓ Pagamento dividido");

            // Passo 5: Separar pedido (duplicado)
            Console.WriteLine("[Marketplace] Separando itens no estoque...");
            Console.WriteLine("✓ Itens separados");

            // Passo 6: Agendar envio (pode ser Correios ou transportadora do vendedor)
            Console.WriteLine("[Marketplace] Agendar envio com opção do vendedor...");
            Console.WriteLine("✓ Envio agendado");

            // Passo 7: Notificar (cliente E vendedor)
            Console.WriteLine("[Marketplace] Notificando partes...");
            Console.WriteLine("  → Cliente notificado");
            Console.WriteLine("  → Vendedor notificado");
            Console.WriteLine("✓ Notificações enviadas");

            Console.WriteLine("\n✅ Pedido marketplace processado com sucesso!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Processamento de Pedidos ===");

            var items = new List<string> { "Notebook", "Mouse", "Teclado" };

            // Processando pedido online
            var onlineProcessor = new OnlineOrderProcessor();
            onlineProcessor.ProcessOrder("CUST001", items, 2500.00m);

            // Processando pedido atacado
            var wholesaleProcessor = new WholesaleOrderProcessor();
            wholesaleProcessor.ProcessOrder("COMP001", items, 5000.00m);

            // Processando pedido marketplace
            var marketplaceProcessor = new MarketplaceOrderProcessor();
            marketplaceProcessor.ProcessOrder("SELL001", items, 3000.00m);

            Console.WriteLine("\n=== PROBLEMAS ===");
            Console.WriteLine("✗ Estrutura do algoritmo duplicada 3 vezes");
            Console.WriteLine("✗ Mudança no fluxo geral = modificar todas as classes");
            Console.WriteLine("✗ Passos comuns (verificar estoque, separar) duplicados");
            Console.WriteLine("✗ Difícil garantir que todos seguem mesma sequência");
            Console.WriteLine("✗ Não há reutilização de código");
            Console.WriteLine("✗ Inconsistência: fácil esquecer passo em alguma classe");
            Console.WriteLine("✗ Adicionar novo canal = duplicar estrutura completa");

            Console.WriteLine("\n=== Problemas de Manutenção ===");
            Console.WriteLine("• Se adicionar passo 'Gerar nota fiscal' após pagamento:");
            Console.WriteLine("  → Precisa modificar 3 classes");
            Console.WriteLine("  → Risco de esquecer em alguma delas");
            Console.WriteLine("• Se mudar ordem dos passos:");
            Console.WriteLine("  → Precisa ajustar em 3 lugares");
            Console.WriteLine("• Se adicionar validação comum:");
            Console.WriteLine("  → Código duplicado 3 vezes");

            Console.WriteLine("\n=== Análise de Código ===");
            Console.WriteLine("Estrutura comum (70% igual):");
            Console.WriteLine("  1. Validar pedido");
            Console.WriteLine("  2. Verificar estoque");
            Console.WriteLine("  3. Calcular valores *");
            Console.WriteLine("  4. Processar pagamento *");
            Console.WriteLine("  5. Separar pedido");
            Console.WriteLine("  6. Agendar envio *");
            Console.WriteLine("  7. Notificar *");
            Console.WriteLine("  (* = varia por tipo)");

            // Perguntas para reflexão:
            // - Como definir estrutura do algoritmo em um só lugar?
            // - Como permitir que subclasses customizem passos específicos?
            // - Como garantir que sequência seja sempre respeitada?
            // - Como reutilizar passos comuns entre implementações?
        }
    }
}
