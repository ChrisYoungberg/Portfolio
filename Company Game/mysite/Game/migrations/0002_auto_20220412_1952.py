# Generated by Django 2.2 on 2022-04-13 01:52

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Game', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='company',
            name='cost',
            field=models.IntegerField(default=0),
            preserve_default=False,
        ),
        migrations.AddField(
            model_name='company',
            name='pay',
            field=models.IntegerField(default=0),
            preserve_default=False,
        ),
    ]
