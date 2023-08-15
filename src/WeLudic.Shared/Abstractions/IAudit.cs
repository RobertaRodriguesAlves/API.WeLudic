namespace WeLudic.Shared.Abstractions;

/// <summary>
/// Interface que define os comportamentos de uma entidade auditável.
/// </summary>
public interface IAudit
{
    /// <summary>
    /// Data de criação da entidade.
    /// </summary>
    DateTime CreatedAt { get; }

    /// <summary>
    /// Data de última atualização da entidade.
    /// </summary>
    DateTime? LastModified { get; }

    /// <summary>
    /// Usuário que atualizou a entidade.
    /// </summary>
    Guid? LastModifiedBy { get; }

    /// <summary>
    /// Indica se a entidade foi deletada.
    /// </summary>
    bool IsDeleted { get; }
}