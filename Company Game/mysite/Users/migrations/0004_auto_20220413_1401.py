# Generated by Django 2.2 on 2022-04-13 20:01

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Users', '0003_account_incomeforday'),
    ]

    operations = [
        migrations.AlterField(
            model_name='account',
            name='incomeforday',
            field=models.BigIntegerField(default=0),
        ),
        migrations.AlterField(
            model_name='account',
            name='money',
            field=models.BigIntegerField(default=1000),
        ),
    ]