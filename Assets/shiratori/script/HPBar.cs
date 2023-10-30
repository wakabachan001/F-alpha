using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image hpBarcurrent;
    private float maxHealth;//�ő�̗�

    //private float currentHealth;//���݂̗̑�

    void Awake()
    {
        //PlayerManager�̓ǂݍ���
        PlayerManager playermanager;
        GameObject obj = GameObject.Find("Player");
        playermanager = obj.GetComponent<PlayerManager>();

        //�ő�̗͂�PlayermManager����Q��
        maxHealth = playermanager.playerHP;

        ////���݂�HP��������
        //currentHealth = maxHealth;
    }

    //�̗͍X�V�֐�
    public void UpdateHP(float currentHealth)
    {
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        hpBarcurrent.fillAmount = currentHealth / maxHealth;
    }
}
