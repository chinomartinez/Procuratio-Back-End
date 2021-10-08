namespace Procuratio.Shared.Infrastructure.Controllers
{
    public static class BasicStringsForControllers
    {
        public const string IntParameter = "{id:int}";

        public const string EntityCreationFormInitializer = "entity-creation-form-initializer";
        public const string EntityEditionFormInitializer = "entity-edition-form-initializer/" + IntParameter;
    }
}
