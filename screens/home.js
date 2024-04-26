import React from 'react';
import { View, TouchableOpacity, Text, StyleSheet, ImageBackground } from 'react-native';

const HomeScreen = ({ navigation }) => {

    const backLogin = () => {
        navigation.navigate('Login');
    };

    return (
        <ImageBackground source={require('../assets/homeBG.png')} style={styles.background}>
            <View style={styles.container}>
                <View style={styles.content}>
                    <View style={styles.formContainer}>
                        <Text style={styles.buttonText}>¡Bienvenido AAA!</Text>

                        <TouchableOpacity style={styles.button}>
                            <Text style={styles.buttonText}>Reservar laboratorio</Text>
                        </TouchableOpacity>
                        <TouchableOpacity style={styles.button}>
                            <Text style={styles.buttonText}>Aprobar préstamos</Text>
                        </TouchableOpacity>
                    </View>
                </View>
                <View style={styles.bottomBar}>
                    <TouchableOpacity style={styles.buttonL} onPress={backLogin}>
                        <Text style={styles.buttonText}>Actualizar base de datos</Text>
                    </TouchableOpacity>
                    <TouchableOpacity style={styles.buttonR}>
                        <Text style={styles.buttonText}>Administrar cuenta</Text>
                    </TouchableOpacity>
                </View>
            </View>
        </ImageBackground>
    );
};

const styles = StyleSheet.create({
    background: {
        flex: 1,
        resizeMode: 'cover', // Opcional, para ajustar la imagen de fondo a la pantalla
        justifyContent: 'center',
        backgroundColor: 'rgba(0,0,0,0.1)', // Opacidad del 80%
    },
    container: {
        flex: 1,
    },
    content: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    formContainer: {
        backgroundColor: 'rgba(0,0,0,0.5)', // Color de fondo semi-transparente
        borderRadius: 10,
        padding: 20,
        width: '90%',
        maxWidth: 400,
        justifyContent: 'center', // Centrar verticalmente
        alignItems: 'center', // Centrar horizontalmente
    },
    bottomBar: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        height: 55,
        backgroundColor: '#151a24', // Color de fondo de la barra inferior
    },
    buttonL: {
        flex: 1,
        height: 55,
        justifyContent: 'center',
        alignItems: 'center',
        borderRightWidth: 0.5,
        borderRightColor: 'white',
        backgroundColor: '#151a24', // Color de fondo del botón
    },
    buttonR: {
        flex: 1,
        height: 55,
        justifyContent: 'center',
        alignItems: 'center',
        borderLeftWidth: 0.5,
        borderLeftColor: 'white',
        backgroundColor: '#151a24', // Color de fondo del botón
    },
    button: {
        backgroundColor: '#4988af', // Color de fondo del botón
        width: 300,
        borderRadius: 5,
        paddingVertical: 10,
        paddingHorizontal: 15,
        alignItems: 'center',
        marginTop: 10,
        marginBottom: 20,
      },
    buttonText: {
        color: '#ffffff', // Color del texto del botón
        fontSize: 16,

    },
});

export default HomeScreen;
