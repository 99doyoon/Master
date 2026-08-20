using UnityEngine;

// 1. 돈이 충분한지 확인한다.

// 2. 충분하다면 돈을 차감한다.

// 3. 아이템을 인벤토리에 넣는다.

// 4. 성공 메시지를 보여준다.

// 돈이 부족하다면
// 구매하지 않고 실패 메시지를 보여준다.
public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int nowGold = 500;

    public int NowGold { get { return nowGold; } }

    public event System.Action OnGoldChanged;

    private void Awake()
    {
        nowGold = 500;
        OnGoldChanged?.Invoke();
    }

    public void AddGold(int gold)
    {
        nowGold += gold;
        OnGoldChanged?.Invoke();
    }

    public bool SpendGold(int gold)
    {
        if (nowGold < gold)
        {
            return false;
        }
        nowGold -= gold;
        OnGoldChanged?.Invoke();
        return true;
    }

    public void TestSpendGold()
    {
        SpendGold(100);
    }
}
