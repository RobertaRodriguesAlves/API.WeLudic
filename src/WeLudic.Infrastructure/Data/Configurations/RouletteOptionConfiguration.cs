using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeLudic.Domain.Entities;

namespace WeLudic.Infrastructure.Data.Configurations;
public class RouletteOptionConfiguration : IEntityTypeConfiguration<RouletteOption>
{
    public void Configure(EntityTypeBuilder<RouletteOption> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(false);

        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.HasData
            (
                new RouletteOption().SetRouletteOptions(1, "DESENHAR O QUE QUISER"),
                new RouletteOption().SetRouletteOptions(2, "DESENHAR O QUE O TERAPEUTA PEDIR"),
                new RouletteOption().SetRouletteOptions(3, "DESENHAR MEUS SONHOS"),
                new RouletteOption().SetRouletteOptions(4, "COLORIR MEUS MEDOS"),
                new RouletteOption().SetRouletteOptions(5, "COLORIR MEUS PESADELOS"),
                new RouletteOption().SetRouletteOptions(6, "COLORIR UM DESENHO"),
                new RouletteOption().SetRouletteOptions(7, "INVENTAR UMA HISTÓRIA"),
                new RouletteOption().SetRouletteOptions(8, "CINETERAPIA"),
                new RouletteOption().SetRouletteOptions(9, "ATIVIDADE COM A FAMÍLIA TODA"),
                new RouletteOption().SetRouletteOptions(10, "ATIVIDADE COM O(S) IRMÃO(S)"),
                new RouletteOption().SetRouletteOptions(11, "ATIVIDADE COM OS PAIS"),
                new RouletteOption().SetRouletteOptions(12, "ATIVIDADE COM A MÃE"),
                new RouletteOption().SetRouletteOptions(13, "ATIVIDADE COM O PAI"),
                new RouletteOption().SetRouletteOptions(14, "ATIVIDADE COM A VOVÓ"),
                new RouletteOption().SetRouletteOptions(15, "ATIVIDADE COM O VOVÔ"),
                new RouletteOption().SetRouletteOptions(16, "ATIVIDADE COM UM AMIGO OU AMIGA"),
                new RouletteOption().SetRouletteOptions(17, "DOBRADURA"),
                new RouletteOption().SetRouletteOptions(18, "MÍMICA"),
                new RouletteOption().SetRouletteOptions(19, "JOGO: O MESTRE MANDOU"),
                new RouletteOption().SetRouletteOptions(20, "ESCUTAR UMA MÚSICA"),
                new RouletteOption().SetRouletteOptions(21, "BRINCAR DE MEDITAR"),
                new RouletteOption().SetRouletteOptions(22, "UTILIZAR BRINQUEDOS ESPECIAIS"),
                new RouletteOption().SetRouletteOptions(23, "CONTAR PIADAS"),
                new RouletteOption().SetRouletteOptions(24, "CONTAR CHARADAS"),
                new RouletteOption().SetRouletteOptions(25, "JOGO: O QUE É O QUE É"),
                new RouletteOption().SetRouletteOptions(26, "LER UMA HISTÓRIA"),
                new RouletteOption().SetRouletteOptions(27, "OUVIR UMA HISTÓRIA"),
                new RouletteOption().SetRouletteOptions(28, "ESCREVER UMA HISTÓRIA"),
                new RouletteOption().SetRouletteOptions(29, "USAR CAIXA DE ARTES"),
                new RouletteOption().SetRouletteOptions(30, "BRINCAR DE ADIVINHE O DESENHO"),
                new RouletteOption().SetRouletteOptions(31, "JOGO: MEMÓRIA & ANIMAIS"),
                new RouletteOption().SetRouletteOptions(32, "JOGO: PRECISO DE AJUDA"),
                new RouletteOption().SetRouletteOptions(33, "JOGO: GOSTO / NÃO GOSTO")
            );
    }
}
