from django.shortcuts import redirect, render
from django.contrib.auth.decorators import login_required
from Users.models import Account
from .models import Company
import math

# Create your views here.
@login_required
def tutorial(request):
    #account
    a = Account.objects.filter(user = request.user).first()

    return render(request, 'tutorial.html', {'a':a})

@login_required
def game(request):
    #account
    a = Account.objects.filter(user = request.user).first()
    #companies
    cs = Company.objects.all()
    #cost
    c = []
    #pay 
    p = []

    if int(cs[0].cost * (1 - (a.pcomp1cost * .1)) * (1 - (a.pallcost * .1))) > 1:
        c.append(int(cs[0].cost * (1 - (a.pcomp1cost * .1)) * (1 - (a.pallcost * .1))))
    else:
        c.append(1)
    c.append(int(cs[1].cost * (1 - (a.pcomp2cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[2].cost * (1 - (a.pcomp3cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[3].cost * (1 - (a.pcomp4cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[4].cost * (1 - (a.pcomp5cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[5].cost * (1 - (a.pcomp6cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[6].cost * (1 - (a.pcomp7cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[7].cost * (1 - (a.pcomp8cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[8].cost * (1 - (a.pcomp9cost * .1)) * (1 - (a.pallcost * .1))))
    c.append(int(cs[9].cost * (1 - (a.pcomp10cost * .1)) * (1 - (a.pallcost * .1))))

    p.append(int((cs[0].pay) * (1 + (a.pcomp1pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[1].pay) * (1 + (a.pcomp2pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[2].pay) * (1 + (a.pcomp3pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[3].pay) * (1 + (a.pcomp4pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[4].pay) * (1 + (a.pcomp5pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[5].pay) * (1 + (a.pcomp6pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[6].pay) * (1 + (a.pcomp7pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[7].pay) * (1 + (a.pcomp8pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[8].pay) * (1 + (a.pcomp9pay * .1) + (a.pallpay * .1))))
    p.append(int((cs[9].pay) * (1 + (a.pcomp10pay * .1) + (a.pallpay * .1))))

    return render(request, 'game.html', {'a':a, 'cs':cs, 'cost':c, 'pay':p})

@login_required
def company(request, ID):
    #account
    a = Account.objects.filter(user = request.user).first()
    #company
    c = Company.objects.filter(pk = ID).first()

    if c.name == 'Taco Bell':
        cost = (c.cost * (1 - (a.pcomp1cost * .1)) * (1 - (a.pallcost * .1)))
        if cost < 1:
            cost = 1
        if a.money - cost >= 0:
            a.money -= cost
            a.comp1 += 1
    if c.name == 'Chick-fil-A':
        cost = (c.cost * (1 - (a.pcomp2cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp2 += 1
    if c.name == 'Pizza Hut':
        cost = (c.cost * (1 - (a.pcomp3cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp3 += 1
    if c.name == "Arby's":
        cost = (c.cost * (1 - (a.pcomp4cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp4 += 1
    if c.name == "Dunkin'":
        cost = (c.cost * (1 - (a.pcomp5cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp5 += 1
    if c.name == "Cinnabon":
        cost = (c.cost * (1 - (a.pcomp6cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp6 += 1
    if c.name == "Wendy's":
        cost = (c.cost * (1 - (a.pcomp7cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp7 += 1
    if c.name == "Krispy Kreme":
        cost = (c.cost * (1 - (a.pcomp8cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp8 += 1
    if c.name == "Baskin-Robbins":
        cost = (c.cost * (1 - (a.pcomp9cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp9 += 1
    if c.name == "Dairy Queen":
        cost = (c.cost * (1 - (a.pcomp10cost * .1)) * (1 - (a.pallcost * .1)))
        if a.money - cost >= 0:
            a.money -= cost
            a.comp10 += 1
        
    #companies
    cs = Company.objects.all()
    #income
    i = ((cs[0].pay * a.comp1) * (1 + (a.pcomp1pay * .1) + (a.pallpay * .1)))
    i += ((cs[1].pay * a.comp2) * (1 + (a.pcomp2pay * .1) + (a.pallpay * .1)))
    i += ((cs[2].pay * a.comp3) * (1 + (a.pcomp3pay * .1) + (a.pallpay * .1)))
    i += ((cs[3].pay * a.comp4) * (1 + (a.pcomp4pay * .1) + (a.pallpay * .1)))
    i += ((cs[4].pay * a.comp5) * (1 + (a.pcomp5pay * .1) + (a.pallpay * .1)))
    i += ((cs[5].pay * a.comp6) * (1 + (a.pcomp6pay * .1) + (a.pallpay * .1)))
    i += ((cs[6].pay * a.comp7) * (1 + (a.pcomp7pay * .1) + (a.pallpay * .1)))
    i += ((cs[7].pay * a.comp8) * (1 + (a.pcomp8pay * .1) + (a.pallpay * .1)))
    i += ((cs[8].pay * a.comp9) * (1 + (a.pcomp9pay * .1) + (a.pallpay * .1)))
    i += ((cs[9].pay * a.comp10) * (1 + (a.pcomp10pay * .1) + (a.pallpay * .1)))
    a.incomeforday = i

    a.save()

    return redirect('game')

@login_required
def nextDay(request):
    #account
    a = Account.objects.filter(user = request.user).first()
    if a.prestige > 0:
        a.money += a.incomeforday * a.prestige
    else: 
        a.money += a.incomeforday
    a.save()
    return redirect('game')

@login_required
def prestigeQuestion(request):
    #account
    a = Account.objects.filter(user = request.user).first()

    return render(request, 'prestigeQuestion.html', {'a':a})

@login_required
def prestige(request):
    #account
    a = Account.objects.filter(user = request.user).first()

    p = math.floor(a.incomeforday * .1)
    a.incomeforday = 0
    a.prestige = a.prestige + p
    a.prestigeBonus = round((a.prestige * .001) + 1, 2)
    a.money = 1000 * a.prestigeBonus
    a.comp1 = 0
    a.comp2 = 0
    a.comp3 = 0
    a.comp4 = 0
    a.comp5 = 0
    a.comp6 = 0
    a.comp7 = 0
    a.comp8 = 0
    a.comp9 = 0
    a.comp10 = 0

    a.save()
    return redirect('game')

@login_required
def prestigeBuy(request):
    #account
    a = Account.objects.filter(user = request.user).first()
    return render(request, 'prestige.html', {'a':a})

@login_required
def prestigeButton(request, ID):
    #account
    a = Account.objects.filter(user = request.user).first()

    if ID == 10:
        if a.prestige - 1000 > 0:
            a.prestige -= 1000
            a.pallcost += 1
    if ID == 11:
        if a.prestige - 80 > 0:
            a.prestige -= 80
            a.pcomp1cost += 1
    if ID == 12:
        if a.prestige - 160 > 0:
            a.prestige -= 160
            a.pcomp2cost += 1
    if ID == 13:
        if a.prestige - 320 > 0:
            a.prestige -= 320
            a.pcomp3cost += 1
    if ID == 14:
        if a.prestige - 640 > 0:
            a.prestige -= 640
            a.pcomp4cost += 1
    if ID == 15:
        if a.prestige - 1280 > 0:
            a.prestige -= 1280
            a.pcomp5cost += 1
    if ID == 16:
        if a.prestige - 2560 > 0:
            a.prestige -= 2560
            a.pcomp6cost += 1
    if ID == 17:
        if a.prestige - 5120 > 0:
            a.prestige -= 5120
            a.pcomp7cost += 1
    if ID == 18:
        if a.prestige - 10240 > 0:
            a.prestige -= 10240
            a.pcomp8cost += 1
    if ID == 19:
        if a.prestige - 20480 > 0:
            a.prestige -= 20480
            a.pcomp9cost += 1
    if ID == 110:
        if a.prestige - 40960 > 0:
            a.prestige -= 40960
            a.pcomp10cost += 1
    if ID == 20:
        if a.prestige - 1000 > 0:
            a.prestige -= 1000
            a.pallpay += 1
    if ID == 21:
        if a.prestige - 80 > 0:
            a.prestige -= 80
            a.pcomp1pay += 1
    if ID == 22:
        if a.prestige - 160 > 0:
            a.prestige -= 160
            a.pcomp2pay += 1
    if ID == 23:
        if a.prestige - 320 > 0:
            a.prestige -= 320
            a.pcomp3pay += 1
    if ID == 24:
        if a.prestige - 640 > 0:
            a.prestige -= 640
            a.pcomp4pay += 1
    if ID == 25:
        if a.prestige - 1280 > 0:
            a.prestige -= 1280
            a.pcomp5pay += 1
    if ID == 26:
        if a.prestige - 2560 > 0:
            a.prestige -= 2560
            a.pcomp6pay += 1
    if ID == 27:
        if a.prestige - 5120 > 0:
            a.prestige -= 5120
            a.pcomp7pay += 1
    if ID == 28:
        if a.prestige - 10240 > 0:
            a.prestige -= 10240
            a.pcomp8pay += 1
    if ID == 29:
        if a.prestige - 20480 > 0:
            a.prestige -= 20480
            a.pcomp9pay += 1
    if ID == 210:
        if a.prestige - 40960 > 0:
            a.prestige -= 40960
            a.pcomp10pay += 1


    a.prestigeBonus = round((a.prestige * .001) + 1, 2)
    a.save()

    return redirect('prestigeBuy')