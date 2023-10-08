"""mysite URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/2.2/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path
from Users import views as userViews
from django.contrib.auth import views as authViews
from django.conf import settings
from django.conf.urls.static import static
from Game import views as gameViews

urlpatterns = [
    path('admin/', admin.site.urls),
    path('register/', userViews.register, name='register'),
    path('login/', authViews.LoginView.as_view(template_name='login.html'), name='login'),
    path('logout/', authViews.LogoutView.as_view(template_name='logout.html'), name='logout'),
    path('', gameViews.game, name='game'),
    path('tutorial', gameViews.tutorial, name='tutorial'),
    path('company/<int:ID>', gameViews.company, name='company'),
    path('nextDay/', gameViews.nextDay, name='nextDay'),
    path('prestige/', gameViews.prestige, name='prestige'),
    path('prestigeBuy/', gameViews.prestigeBuy, name='prestigeBuy'),
    path('prestigeButton/<int:ID>', gameViews.prestigeButton, name='prestigeButton'),
    path('prestigeQuestion/', gameViews.prestigeQuestion, name='prestigeQuestion')
] + static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)