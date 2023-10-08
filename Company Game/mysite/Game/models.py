from operator import mod
from django.db import models

# Create your models here.
class Company(models.Model):
    name = models.CharField(max_length=100)
    desc = models.CharField(max_length=500)
    image = models.ImageField(upload_to='compPics')
    cost = models.BigIntegerField()
    pay = models.BigIntegerField()

    def __str__(self):
        return self.name