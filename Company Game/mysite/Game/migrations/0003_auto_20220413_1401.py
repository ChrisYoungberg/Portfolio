# Generated by Django 2.2 on 2022-04-13 20:01

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Game', '0002_auto_20220412_1952'),
    ]

    operations = [
        migrations.AlterField(
            model_name='company',
            name='pay',
            field=models.BigIntegerField(),
        ),
    ]
