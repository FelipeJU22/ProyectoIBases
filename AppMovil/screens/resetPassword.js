import React, { useState, useEffect } from 'react';
import { View, TextInput, Text, TouchableOpacity, Button, Alert, StyleSheet, ImageBackground } from 'react-native';
import { FontAwesome } from '@expo/vector-icons';
import { cambiarContraseña } from '../DataBase_SQLite/DBTables';
import md5 from 'md5';


const ResetPasswordScreen = ({navigation, route}) => {
  const { email } = route.params;
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [passwordsMatch, setPasswordsMatch] = useState(false);

  const handleConfirmPassword = () => {
    const passwordsMatch = password === confirmPassword;
    setPasswordsMatch(passwordsMatch);
  };

  useEffect(() => {
    handleConfirmPassword();
  }, [password, confirmPassword]);

  const handlePasswordChange = (value, field) => {
    if (field === 'password') {
      setPassword(value);
    } else if (field === 'confirmPassword') {
      setConfirmPassword(value);
    }
  };

  const handleResetPassword = () => {
    if (passwordsMatch) {
      const hashedPassword = cifrarPassword(password);
      cambiarContraseña(email, hashedPassword)
        

      fetch(`http://192.168.100.56:5095/Profesor/CambiarContraseñaProfesor`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({ correo: email, password: hashedPassword }),
        })
          .then(response => {
            if (!response.ok) {
              throw new Error('Error al cambiar la contraseña');
            }
            Alert.alert('Contraseña restablecida con éxito');
            navigation.navigate('Home', { email: email });
          })
          .catch(error => {
            console.error('Error al restablecer la contraseña:', error);
            Alert.alert('Error al restablecer la contraseña');
          });
    } else {
      Alert.alert('Las contraseñas no coinciden, intente de nuevo');
    }
  };

  const cifrarPassword = (password) => {
    return md5(password);
  }

  return (
    <ImageBackground source={require('../assets/homeBG.png')} style={styles.background}>
      <View style={styles.container}>
        <View style={styles.formContainer}>
          <Text style={styles.buttonText}>Escribe la nueva contraseña</Text>
          <TextInput
            style={styles.passwordInput}
            placeholder="Nueva contraseña"
            value={password}
            secureTextEntry={true}
            onChangeText={(value) => handlePasswordChange(value, 'password')}
          />
          <View style={styles.passwordContainer}>
            <TextInput
              style={styles.passwordInput}
              placeholder="Confirmar contraseña"
              value={confirmPassword}
              secureTextEntry={true}
              onChangeText={(value) => handlePasswordChange(value, 'confirmPassword')}
            />
            {(password.length > 0 && confirmPassword.length > 0) && (
              passwordsMatch ? (
                <FontAwesome style={styles.toggle} name="check" size={35} color="green" />
              ) : (
                <FontAwesome style={styles.toggle} name="times" size={35} color="red" />
              )
            )}
          </View>
          <TouchableOpacity style={styles.button} onPress={handleResetPassword}>
            <Text style={styles.buttonText}>Restablecer contraseña</Text>
          </TouchableOpacity>
        </View>
      </View>
    </ImageBackground>
  );
};

const styles = StyleSheet.create({
  background: {
    flex: 1,
    resizeMode: 'cover',
    justifyContent: 'center',
    backgroundColor: 'rgba(0,0,0,0.1)',
  },
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 20,
  },
  formContainer: {
    backgroundColor: 'rgba(0,0,0,0.5)',
    borderRadius: 10,
    padding: 20,
    width: '90%',
    maxWidth: 400,
  },
  button: {
    backgroundColor: '#4988af',
    width: 300,
    borderRadius: 5,
    paddingVertical: 5,
    paddingHorizontal: 15,
    alignItems: 'center',
    marginTop: 10,
  },
  buttonText: {
    color: '#ffffff',
    fontSize: 16,
    textAlign: 'center',
    padding: 15,
  },
  input: {
    width: '84%',
    marginBottom: 20,
    marginRight: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
    backgroundColor: '#fff',
  },
  passwordContainer: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  passwordInput: {
    width: '84%',
    marginBottom: 20,
    paddingVertical: 10,
    paddingHorizontal: 15,
    borderWidth: 1,
    borderColor: '#ccc',
    borderRadius: 5,
    backgroundColor: '#fff',
  },
  toggle: {
    padding: 10,
    marginBottom: 15,
  },
});

export default ResetPasswordScreen;
