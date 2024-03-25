using System;
using System.Reflection;

namespace ReflectionDemoPrep2024Tests
{
	public class ReflectionTest
	{
		internal static object? GetInstance(string project, string className, params object?[]? values)
		{
			if (string.IsNullOrWhiteSpace(className))
			{
				Assert.Fail("className cannot be null or empty.");
			}

			var obj = Type.GetType($"{project}.{className}, {project}");
			if (obj is null)
			{
				Assert.Fail($"{className} class not found.");
			}

			object? instance;
			try
			{
				instance = Activator.CreateInstance(obj, values);
			}
			catch (Exception ex)
			{
				instance = null;
				Assert.Fail($"Could not create instance of class {className} with error: {ex.Message}");
			}
			return instance;
		}

		internal static MethodInfo GetMethod(object objectUnderTest, string methodName)
		{
			if (string.IsNullOrWhiteSpace(methodName))
			{
				Assert.Fail("methodName cannot be null or whitespace.");
			}

			var method = objectUnderTest.GetType()
				.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);

			if (method is null)
			{
				Assert.Fail($"{methodName} method not found.");
			}

			return method;
		}

		internal static PropertyInfo GetProperty(object objectUnderTest, string propertyName)
		{
			if (string.IsNullOrWhiteSpace(propertyName))
			{
				Assert.Fail("propertyName cannot be null or whitespace.");
			}

			var property = objectUnderTest.GetType()
				.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

			if (property is null)
			{
				Assert.Fail($"{propertyName} property not found.");
			}

			return property;
		}

		internal static FieldInfo GetPrivateField(object objectUnderTest, string fieldName)
		{
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                Assert.Fail("fieldName cannot be null or whitespace.");
            }

            var field = objectUnderTest.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (field is null)
            {
                Assert.Fail($"{fieldName} field not found.");
            }

            return field;
        }

		internal static bool IsPropertyAutoImplemented(object objectUnderTest, string propertyName)
		{
			var property = GetProperty(objectUnderTest, propertyName);

			return property?.DeclaringType?.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.Any(field => field.Name.Contains($"<{property.Name}>")) ?? false; 
		}

		internal static bool IsPropertyWriteable(object objectUnderTest, string propertyName)
		{
			return GetProperty(objectUnderTest, propertyName).CanWrite;
		}
    }
}

