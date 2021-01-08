// pages/mine/userInfo/userInfo.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    userInfo: {},
    gender: ''
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    const self = this;
    wx.getUserInfo({
      success: function (res) {
        console.log(res)
        self.setData({
          userInfo: res.userInfo,
          gender: res.userInfo.gender == 1 ? '男' : '女'
        });
      }
    })
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {
    
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {
    
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  },

  getUserInfo(res) {
    console.log(res.detail.userInfo)
    this.setData({
      userInfo: res.detail.userInfo,
      gender: res.detail.userInfo.gender == 1 ? '男' : '女'
    })
  },
})