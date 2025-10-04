using BankApi.Data;
using BankApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<TransactionEntry> Transactions => Set<TransactionEntry>();
    public DbSet<InterestRule> InterestRules => Set<InterestRule>();
    public DbSet<DemandRate> DemandRates => Set<DemandRate>();
    public DbSet<FxRate> FxRates => Set<FxRate>();
    public DbSet<DailyAccrual> DailyAccruals => Set<DailyAccrual>();
    public DbSet<DailyBalance> DailyBalances => Set<DailyBalance>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);

        b.Entity<Account>().HasIndex(a => a.AccountNo).IsUnique();
        b.Entity<Account>().Property(a => a.Balance).HasColumnType("decimal(18,2)");
        b.Entity<Account>().Property(a => a.RowVersion).IsRowVersion();

        b.Entity<TransactionEntry>().Property(t => t.Amount).HasColumnType("decimal(18,2)");
        b.Entity<TransactionEntry>().Property(t => t.BalanceAfter).HasColumnType("decimal(18,2)");

        b.Entity<InterestRule>().HasIndex(r => new { r.AccountClass, r.TermFromM, r.TermToM, r.EffectiveFrom });
        b.Entity<DemandRate>().HasIndex(r => new { r.Currency, r.EffectiveFrom });
        b.Entity<FxRate>().HasIndex(r => new { r.QuoteCurrency, r.EffectiveFrom });

        b.Entity<DailyAccrual>().HasIndex(x => new { x.AccountId, x.ValueDate });
        b.Entity<DailyBalance>().HasIndex(x => new { x.AccountId, x.ValueDate });

        // Seed mẫu (có thể chuyển sang DataSeeder nếu thích)
        var eff = new DateTime(2025, 1, 1);
        b.Entity<DemandRate>().HasData(
            new DemandRate { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Currency = "VND", Rate = 0.0025m, EffectiveFrom = eff },
            new DemandRate { Id = Guid.Parse("11111111-1111-1111-1111-111111111112"), Currency = "USD", Rate = 0.0015m, EffectiveFrom = eff }
        );
        b.Entity<InterestRule>().HasData(
            new InterestRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222221"), AccountClass = AccountClass.Saving, TermFromM = 1, TermToM = 3, Rate = 0.035m, Payout = InterestPayout.EndOfTerm, IsDefault = true, EffectiveFrom = eff },
            new InterestRule { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), AccountClass = AccountClass.Saving, TermFromM = 6, TermToM = 12, Rate = 0.055m, Payout = InterestPayout.EndOfTerm, IsDefault = true, EffectiveFrom = eff }
        );
        b.Entity<FxRate>().HasData(
            new FxRate { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), BaseCurrency = "VND", QuoteCurrency = "USD", Mid = 25400m, EffectiveFrom = eff }
        );
    }
}

