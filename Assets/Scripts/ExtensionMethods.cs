using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethods
{
    public static async UniTask ChangeAlphaAsync(this Image image, float targetAlpha, float changingStep, int durationStepInMilliseconds)
    {
        while (Mathf.Abs(image.color.a - targetAlpha) > 0.001f)
        {
            float alpha = Mathf.MoveTowards(image.color.a, targetAlpha, changingStep);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            await UniTask.Delay(durationStepInMilliseconds);
        }
    }

    public static async UniTask MoveAsync(this Transform transform, Vector3 targetPosition, float movingStep)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingStep);
            await UniTask.Yield();
        }
    }

    public static void SetX(this Transform transform, float x) => 
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
}