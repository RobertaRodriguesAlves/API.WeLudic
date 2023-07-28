using JsonNet.ContractResolvers;
using Newtonsoft.Json;

namespace WeLudic.Shared.Extensions;

/// <summary>
/// Extensões para JSON.
/// </summary>
public static class JsonExtensions
{
    private static readonly PrivateSetterContractResolver ContractResolver = new();

    private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings().Configure();

    /// <summary>
    /// Desserializa o JSON para o tipo especificado.
    /// </summary>
    /// <typeparam name="T">Tipo de objeto para o qual desserializar.</typeparam>
    /// <param name="value">Objeto a ser desserializado.</param>
    /// <returns>O objeto desserializado da string JSON.</returns>
    public static T FromJson<T>(this string value)
    {
        return (T)((value != null) ? ((object)JsonConvert.DeserializeObject<T>(value, JsonSettings)) : ((object)default(T)));
    }

    /// <summary>
    /// Serializa o objeto especificado em uma string JSON.
    /// </summary>
    /// <param name="value">Objeto a ser serializado.</param>
    /// <param name="formatting">Formatação da string JSON.</param>
    /// <returns>Uma representação de string JSON do objeto.</returns>
    public static string ToJson<T>(this T value, Formatting formatting = Formatting.None)
    {
        return (value != null) ? JsonConvert.SerializeObject(value, formatting, JsonSettings) : null;
    }

    /// <summary>
    /// Aplica a configuração padrão no Serializador/Desserializador.
    /// </summary>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static JsonSerializerSettings Configure(this JsonSerializerSettings settings)
    {
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
        settings.NullValueHandling = NullValueHandling.Ignore;
        settings.Formatting = Formatting.None;
        settings.ContractResolver = ContractResolver;
        return settings;
    }
}