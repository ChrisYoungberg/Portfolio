# Generated by Django 2.2 on 2022-04-13 02:54

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Users', '0002_auto_20220411_1456'),
    ]

    operations = [
        migrations.AddField(
            model_name='account',
            name='incomeforday',
            field=models.IntegerField(default=0),
        ),
    ]
