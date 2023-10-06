using Supabase;
using Supabase.Gotrue;
using Client = Supabase.Client;

public static class SupabaseUtils {
    public static Client? Supabase {get; private set;}

    public static async Task InitializeAsync()
    {
        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
        var key = Environment.GetEnvironmentVariable("SUPABASE_ANON");

        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = false
        };

        var supabase = new Supabase.Client(url, key, options);
        await supabase.InitializeAsync();

        SupabaseUtils.Supabase = supabase;
    }

    public static async Task<User?> IsAuthenticatedAsync(string jwt)
    {
        if (jwt == null) return null;
        if (SupabaseUtils.Supabase == null) return null;
        var user = await SupabaseUtils.Supabase.Auth.GetUser(jwt);

        return user;

    }
}