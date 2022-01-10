namespace Shop.Shared
{
    public record Error(string Code, string Message)
    {
        #region Static Interface

        public static Error Required(string identifier = default) =>
            identifier is null
                ? new("required", "Value is required.")
                : new("required", $"{identifier} is required.");

        #endregion
    }
}
