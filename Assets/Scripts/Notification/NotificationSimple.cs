using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

[CreateAssetMenu(fileName = "Notification", menuName = "ScriptableObjects/Notification", order = 0)]
public class NotificationSimple : ScriptableObject
{
    [SerializeField] string idCanal;
    [SerializeField] string nameCanal;
    [SerializeField] string descriptionCanal;
    [SerializeField] string iconSmall;
    [SerializeField] string iconLarge;

    public void Start()
    {
#if UNITY_ANDROID
        RequestAuhtorization();
        RegisterNotificationChannel();
#endif
    }

#if UNITY_ANDROID
    //Request authorization to send notifications
    public void RequestAuhtorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    //Register a Notification Channel
    
    public void RegisterNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel
        {
            Id = idCanal,
            Name = nameCanal,
            Importance = Importance.High,
            Description = descriptionCanal
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification(string title, string text, int fireTimeInHours)
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        notification.SmallIcon = iconSmall;
        notification.LargeIcon = iconLarge;

        AndroidNotificationCenter.SendNotification(notification, idCanal);
    }       
#endif      
}
